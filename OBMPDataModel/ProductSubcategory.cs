#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;

namespace OBMPDataModel	
{
	public partial class ProductSubcategory
	{
		private int _iD;
		public virtual int ID
		{
			get
			{
				return this._iD;
			}
			set
			{
				this._iD = value;
			}
		}
		
		private int _productCategoryID;
		public virtual int ProductCategoryID
		{
			get
			{
				return this._productCategoryID;
			}
			set
			{
				this._productCategoryID = value;
			}
		}
		
		private string _name;
		public virtual string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}
		
		private DateTime _modifiedDate;
		public virtual DateTime ModifiedDate
		{
			get
			{
				return this._modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
		
	}
}
#pragma warning restore 1591
