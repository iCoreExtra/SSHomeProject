using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSHomeCommon
{
    public class Criteria
    {

        #region Private Variables

        private PageOption _pageOption = new PageOption();

        private List<Parameter> _parameters = new List<Parameter>();

        private List<SortOption> _sortOptions = new List<SortOption>();

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Gets or sets the page option.
        /// </summary>
        /// <value>The page option.</value>
        /// <remarks></remarks>
        public PageOption PageOption { get { return _pageOption; } set { _pageOption = value; } }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        /// <remarks></remarks>
        public List<Parameter> Parameters { get { return _parameters; } set { _parameters = value; } }

        /// <summary>
        /// Gets or sets the sort options.
        /// </summary>
        /// <value>The sort options.</value>
        /// <remarks></remarks>
        public List<SortOption> SortOptions { get { return _sortOptions; } set { _sortOptions = value; } }

        /// <summary>
        /// Gets the <see cref="MapleTree.Common.Parameter"/> with the specified name.
        /// </summary>
        /// <remarks></remarks>
        public Parameter this[string name]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new NullReferenceException("name can not be null or empty");
                }

                return _parameters.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
            }
        }

        #endregion Properties

        /// <summary>
        /// Determines whether [contains] [the specified name].
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if [contains] [the specified name]; otherwise, <c>false</c>.</returns>
        /// <remarks></remarks>
        public bool Contains(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new NullReferenceException("name can not be null or empty");
            }

            return _parameters.Any(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        }
    }

    public static class CriteriaExtension
    {
        /// <summary>
        /// Toes the sort SQL.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ToSortSQL(this Criteria criteria)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in criteria.SortOptions)
            {
                builder.AppendFormat("{0} {1},", item.PropertyName, (item.Ascending ? "desc" : "asc"));
            }

            if (criteria.SortOptions.Count == 0)
            {
                return null;
            }
            else if (criteria.SortOptions.Count == 1)
            {
                builder.Remove(builder.Length - 1, 1);
            }

            return builder.ToString();
        }
    }
}
