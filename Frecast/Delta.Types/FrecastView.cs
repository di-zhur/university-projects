using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delta.Types
{
    public class FrecastView
    {
        [Browsable(false)]
        public Guid Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Автор")]
        public string Owner { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Дата")]
        public DateTime? Date { get; set; }

        [DisplayName("Состояние")]
        public string State { get; set; }
    }
}

