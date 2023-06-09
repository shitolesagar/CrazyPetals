﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CrazyPetals.Entities.WebViewModels;
using Microsoft.AspNetCore.Http;

namespace CrazyPetals.Abstraction.Service
{
    public interface IFileServices
    {
        Task<string> SaveImageAndReturnRelativePath(IFormFile file, params string[] folders);
    }
}