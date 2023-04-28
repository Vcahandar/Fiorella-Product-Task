﻿using EntityFramework_Slider.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace EntityFramework_Slider.Helpers
{
    public static class FileHelper
    {
        public static bool CheckFileType(this IFormFile file,string pattern)
        {
            return file.ContentType.Contains(pattern);
        }

        public static bool CheckFileSize(this IFormFile file,long size)
        {
            return file.Length/1024 > size;
        }

        public static void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }


        public static string GetFilePath(string root,string folder,string file)
        {
            return Path.Combine(root, folder, file);
        }


        public static string CreateFile(this IFormFile file, IWebHostEnvironment env, string folderName)
        {
            string fileName = String.Concat(Guid.NewGuid().ToString(), file.FileName);
            string path = GetFilePath(env.WebRootPath, folderName, fileName);
            using (FileStream stream = new(path, FileMode.Create))
                file.CopyTo(stream);
            return fileName;
        }



    }
}
