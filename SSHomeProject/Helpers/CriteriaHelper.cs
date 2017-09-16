using MvcContrib.UI.Grid;
using SSHomeCommon;
using SSHomeCommon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSHomeProject.Helpers
{
    public static class CriteriaHelper
    {
        public static Criteria New()
        {
            return new Criteria();
        }
        public static Criteria Add(this Criteria criteria, int? page)
        {
            criteria.PageOption = new PageOption { pagenumber = page ?? 1, pagesize = ConfigHelper.GetPageSize() };
            return criteria;
        }

        public static Criteria Add(this Criteria criteria, GridSortOptions sortOption)
        {
            if (sortOption.Column != null)
            {
                criteria.SortOptions.Add(new SortOption
                {
                    PropertyName = sortOption.Column,
                    Ascending = (sortOption.Direction == MvcContrib.Sorting.SortDirection.Ascending)
                });
            }

            return criteria;
        }

        public static Criteria Add(this Criteria criteria, string propertyName, object value)
        {
            if (string.IsNullOrWhiteSpace(propertyName) == false)
            {
                criteria.Parameters.Add(new Parameter { Name = propertyName, Value = value });
            }
            else
            {
                throw new InvalidOperationException("Invalid property name");
            }
            return criteria;
        }
    }
}