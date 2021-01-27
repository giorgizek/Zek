﻿using Microsoft.EntityFrameworkCore;
using System;
using Zek.Data.Entity;

namespace Zek.Model.Notification
{
    public class Sms
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }

        /// <summary>
        /// Type of sms (example: 1=person, 2=booking, 3=order)
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Foreign key ID (example: person, booking, order...)
        /// </summary>
        public int? FkId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Body { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateDate { get; set; }

        #region Custom properties

        public SmsStatus Status
        {
            get => (SmsStatus)StatusId;
            set => StatusId = (int)value;
        }

        #endregion
    }


    public class SmsMap<TSms> : EntityTypeMap<TSms>
        where TSms : Sms
    {
        public SmsMap(ModelBuilder builder) : base(builder)
        {
            ToTable("Sms", "Notification");
            HasKey(x => x.Id);

            Property(x => x.Id).ValueGeneratedOnAdd();
            Property(x => x.Start).HasColumnTypeDateTime();
            Property(x => x.End).HasColumnTypeDateTime();
            Property(x => x.Body).IsRequired().HasMaxLength(1000);
            Property(x => x.CreateDate).HasColumnTypeDateTime();

            Ignore(x => x.Status);

            HasIndex(x => new { x.Start, x.End });
            HasIndex(x => new { x.ApplicationId, x.TypeId, x.FkId });
            HasIndex(x => x.StatusId);

        }
    }
}
