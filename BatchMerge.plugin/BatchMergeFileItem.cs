using System.IO;

namespace BatchMerge.plugin
{
    public class BatchMergeFileItem
    {
        public string FileName { get; set; }

        public string DisplayName
        {
            get
            {
                return Path.GetFileName(FileName);
            }
        }
    }
}
