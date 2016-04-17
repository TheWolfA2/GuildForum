﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GuildForum.Models
{
    public class ThreadReply
    {
        #region Columns
        [Key]
        public int ID { get; set; }
        [MinLength(5), Required]
        public string Content { get; set; }
        [DataType(DataType.DateTime), Required]
        public DateTime PostDate { get; set; }
        [ForeignKey("Thread")]
        public int ThreadID { get; set; }
        #endregion

        #region Navigation Properties
        public virtual Thread Thread { get; set; }
        #endregion
    }
}