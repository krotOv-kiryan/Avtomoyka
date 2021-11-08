using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avtomoyka1
{
    public class Model
    {
       // EditUser editUser = new EditUser();

        public event EventHandler UsersChanged;
        public event EventHandler<string> CreateMessage;
    }
        
}
