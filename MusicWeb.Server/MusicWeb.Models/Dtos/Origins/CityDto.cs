﻿using MusicWeb.Models.Dtos.Origins.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Origins
{
    public class CityDto : CreateCityDto
    {
        public int Id { get; set; }
    }
}
