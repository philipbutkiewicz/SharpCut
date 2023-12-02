using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCut
{
    public class ExportSettings
    {
        #region Properties

        /// <summary>
        /// Merge all files into one?
        /// </summary>
        public bool MergeFiles = false;

        /// <summary>
        /// Container index (export form).
        /// </summary>
        public int Container = 0;

        #endregion
    }
}
