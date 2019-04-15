﻿using System;
using System.Collections.Generic;

namespace DanceCoolDataAccessLogic.Entities
{
    public partial class LessonType
    {
        public LessonType()
        {
            Lesson = new HashSet<Lesson>();
        }

        public int Id { get; set; }
        public string LessonTypeName { get; set; }

        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
