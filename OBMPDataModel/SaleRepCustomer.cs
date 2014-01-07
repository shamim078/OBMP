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
using System.ComponentModel.DataAnnotations;

namespace OBMPDataModel	
{
	public partial class SaleRepCustomer
	{
		private int _iD;
		[Required()]
		[Key()]
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
		
		private int _salesRepresentativeID;
		[Required()]
		public virtual int SalesRepresentativeID
		{
			get
			{
				return this._salesRepresentativeID;
			}
			set
			{
				this._salesRepresentativeID = value;
			}
		}
		
		private int _customerID;
		[Required()]
		public virtual int CustomerID
		{
			get
			{
				return this._customerID;
			}
			set
			{
				this._customerID = value;
			}
		}
		
		private DateTime? _mappedDate;
		[DataType(DataType.Date)]
		public virtual DateTime? MappedDate
		{
			get
			{
				return this._mappedDate;
			}
			set
			{
				this._mappedDate = value;
			}
		}
		
	}
}
#pragma warning restore 1591
