using System;
using System.IO;
using System.IO.Compression;

namespace Zats_HW6
{
	class Program
	{
		static void Main(string[] args)
		{
			string dirPath = @"C:\Users\ZATS"; //ПУТЬ К ПАПКЕ

			DateTime date = DateTime.Now.AddDays(-14);

			string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

			string file = @"\New.txt";

			string zipName = @"\New.zip";

			FileStream textFile = new FileStream(path + file, FileMode.OpenOrCreate);

			DirectoryInfo dir = new DirectoryInfo(dirPath);

			using (StreamWriter sw = new StreamWriter(textFile))
			{
				DirectoryTree(dir, date, "", sw);
			}


			Zipping(path+file,path+zipName);
		}

		private static void Zipping(string inputFl, string outputFl)
		{
			FileStream src = File.OpenRead(inputFl);
			FileStream dst = File.Create(outputFl);
			GZipStream zipStream = new GZipStream(dst, CompressionMode.Compress);
			int oneByte = src.ReadByte();

			while (oneByte != -1)
			{
				zipStream.WriteByte((byte)oneByte);
				oneByte = src.ReadByte();
			}

			src.Close();
			zipStream.Close();
			dst.Close();
		}

		private static void DirectoryTree(DirectoryInfo item, DateTime date, string del, StreamWriter file)
		{
			if (item.GetDirectories().Length>0)
			{
				foreach (var variable in item.GetDirectories())
				{
					file.WriteLine($@"{del}{variable.Name}");
					try
					{
						if (variable.GetDirectories().Length > 0)
						{
							DirectoryTree(variable, date, del + "     ", file);
						}

						FileTree(variable, date, del + "    ", file);
					}
					catch
					{

						//FileTree(variable, date, del + "    ", file);
						file.WriteLine("Нет Доступа");
					}
				}
			}
			FileTree(item,date,del, file);
			
		}

		private static void FileTree(DirectoryInfo item, DateTime date,string del, StreamWriter file)
		{
			foreach (var variable in item.GetFiles())
			{
				if (variable.CreationTime< date)
				{
					file.WriteLine($@"{del}{variable.Name}");
				}
			}
		}
	}
}
