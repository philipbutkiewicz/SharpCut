using System.Collections.Generic;

namespace BatchMerge.plugin
{
    public class BatchMergeJobItem
    {
        #region Enums

        public enum JobStatus
        {
            Success, Error, Queued, Started
        }

        #endregion

        #region Properties

        public string OutputName { get; set; }

        public List<BatchMergeFileItem> Items { get; set; } = new List<BatchMergeFileItem>();

        public JobStatus Status { get; set; } = JobStatus.Queued;

        public float Progress = 0f;

        public string DisplayName
        {
            get
            {
                string displayName = string.Format(Resources.BatchMergeJobItemDisplayName, Items.Count.ToString());
                foreach (BatchMergeFileItem item in Items)
                {
                    displayName += $"{item.DisplayName} ,";
                }

                return displayName.TrimEnd(new char[] { ',', ' '});
            }
        }

        #endregion
    }
}
