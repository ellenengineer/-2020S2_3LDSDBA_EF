using System;
using System.Collections.Generic;

#nullable disable

namespace EF.Models
{
    public partial class TipoProd
    {
        public TipoProd()
        {
            Produtos = new HashSet<Produto>();
        }

        public int CodTipoProd { get; set; }
        public string NomeTipoProd { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
