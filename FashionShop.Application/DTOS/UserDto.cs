﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Application.DTOS
{
    public class UserDto
    {
        public string UserId {  get; set; }
        public string Email { get; set; }
        public string Token { get; set; } 
        public string DisplayName { get; set; }
    }
}
