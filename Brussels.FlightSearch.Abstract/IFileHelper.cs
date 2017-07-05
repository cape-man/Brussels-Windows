using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brussels.FlightSearch.Abstract
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);

        string ReadFile(string filename);
        bool IsFileExist(string filename);
    }
}
