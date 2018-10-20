using System;
using FileHelper.Core;
using FileHelper.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileHelper.Api.Controllers
{
    [Route("[controller]")]
    public class FileSorterController : Controller
    {
        private IFileSorterService _fileSorterService = new FileSorterService();

        // POST /filesorter
        [HttpPost]
        public void SortXmlFile([FromBody] StringWrapper data)
        {
            try
            {
                string file = data.File;
                _fileSorterService.SortFile(file);

                Response.StatusCode = 200;
            }
            catch (Exception e)
            {
                if (e is InvalidFileException)
                    Response.StatusCode = 404;

                throw new InvalidFileException("Oops, something went wrong!", e);
            }
        }
    }
}