﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyRemember.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Persistence.Configuration.Auth
{
    public class AuthControllerSettingsConfiguration : IEntityTypeConfiguration<AuthControllerSettings>
    {
        public void Configure(EntityTypeBuilder<AuthControllerSettings> entity)
        {

        }
    }
}