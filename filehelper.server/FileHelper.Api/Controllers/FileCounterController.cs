using System;
using FileHelper.Core;
using FileHelper.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileHelper.Api.Controllers
{
    [Route("[controller]")]
    public class FileCounterController : Controller
    {
        private IFileCounterService _fileCounterService = new FileCounterService();

        // POST /filecounter
        [HttpPost]
        public int CountFilesInDirectory([FromBody] StringWrapper data)
        {
            try
            {
                string dir = data.Directory;
                int files = _fileCounterService.CountXmlFiles(dir);

                Response.StatusCode = 200;
                return files;
            }
            catch (Exception e)
            {
                if (e is InvalidDirectoryException)
                    Response.StatusCode = 404;

                throw new InvalidDirectoryException("Oops, something went wrong!", e);
            }
        }
    }
}