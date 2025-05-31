using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IGetFunc<TOut, TIn>
    {
        public TOut Get(TIn tin);
    }

    public interface IGetFunc<TOut>
    {
        public TOut Get();
    }
}
