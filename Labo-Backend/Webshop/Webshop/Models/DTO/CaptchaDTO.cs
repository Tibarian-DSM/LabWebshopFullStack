﻿using System.ComponentModel.DataAnnotations;

namespace Webshop.API.Models.DTO
{
    public class CaptchaDTO
    {
        [Required]
        public required string Token { get; set; }
    }
}
