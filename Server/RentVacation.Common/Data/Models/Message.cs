﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentVacation.Common.Data.Models
{
    public class Message
    {
        public string serializedData;

        public Message(object data) => this.Data = data;

        private Message()
        {
        }

        public int Id { get; private set; }

        public Type Type { get; private set; }

        public bool IsPublished { get; private set; }

        public void MarkAsPublished() => this.IsPublished = true;

        [NotMapped]
        public object Data
        {
            get => JsonConvert.DeserializeObject(this.serializedData, this.Type,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            set
            {
                this.Type = value.GetType();

                this.serializedData = JsonConvert.SerializeObject(value,
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}
