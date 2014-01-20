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
using OBMPDataModel;

namespace OBMPDataModel	
{
	public partial class Product
	{
		private long _iD;
		[Required()]
		[Key()]
		public virtual long ID
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
		
		private string _name;
		[StringLength(100)]
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
		
		private string _partnerProductName;
		[StringLength(100)]
		public virtual string PartnerProductName
		{
			get
			{
				return this._partnerProductName;
			}
			set
			{
				this._partnerProductName = value;
			}
		}
		
		private string _sSOTProductName;
		[StringLength(100)]
		public virtual string SSOTProductName
		{
			get
			{
				return this._sSOTProductName;
			}
			set
			{
				this._sSOTProductName = value;
			}
		}
		
		private string _sAPProductName;
		[StringLength(100)]
		public virtual string SAPProductName
		{
			get
			{
				return this._sAPProductName;
			}
			set
			{
				this._sAPProductName = value;
			}
		}
		
		private string _gSMISProductName;
		[StringLength(100)]
		public virtual string GSMISProductName
		{
			get
			{
				return this._gSMISProductName;
			}
			set
			{
				this._gSMISProductName = value;
			}
		}
		
		private byte? _partnerShareType;
		public virtual byte? PartnerShareType
		{
			get
			{
				return this._partnerShareType;
			}
			set
			{
				this._partnerShareType = value;
			}
		}
		
		private string _shareValue1;
		[StringLength(50)]
		public virtual string ShareValue1
		{
			get
			{
				return this._shareValue1;
			}
			set
			{
				this._shareValue1 = value;
			}
		}
		
		private string _shareValue2;
		[StringLength(50)]
		public virtual string ShareValue2
		{
			get
			{
				return this._shareValue2;
			}
			set
			{
				this._shareValue2 = value;
			}
		}
		
		private string _shareValue3;
		[StringLength(50)]
		public virtual string ShareValue3
		{
			get
			{
				return this._shareValue3;
			}
			set
			{
				this._shareValue3 = value;
			}
		}
		
		private string _shareValue4;
		[StringLength(50)]
		public virtual string ShareValue4
		{
			get
			{
				return this._shareValue4;
			}
			set
			{
				this._shareValue4 = value;
			}
		}
		
		private string _shareValue5;
		[StringLength(50)]
		public virtual string ShareValue5
		{
			get
			{
				return this._shareValue5;
			}
			set
			{
				this._shareValue5 = value;
			}
		}
		
		private string _shareValue6;
		[StringLength(50)]
		public virtual string ShareValue6
		{
			get
			{
				return this._shareValue6;
			}
			set
			{
				this._shareValue6 = value;
			}
		}
		
		private string _shareValue7;
		[StringLength(50)]
		public virtual string ShareValue7
		{
			get
			{
				return this._shareValue7;
			}
			set
			{
				this._shareValue7 = value;
			}
		}
		
		private string _shareValue8;
		[StringLength(50)]
		public virtual string ShareValue8
		{
			get
			{
				return this._shareValue8;
			}
			set
			{
				this._shareValue8 = value;
			}
		}
		
		private string _shareValue9;
		[StringLength(50)]
		public virtual string ShareValue9
		{
			get
			{
				return this._shareValue9;
			}
			set
			{
				this._shareValue9 = value;
			}
		}
		
		private string _shareValue10;
		[StringLength(50)]
		public virtual string ShareValue10
		{
			get
			{
				return this._shareValue10;
			}
			set
			{
				this._shareValue10 = value;
			}
		}
		
		private string _description;
		[StringLength(250)]
		public virtual string Description
		{
			get
			{
				return this._description;
			}
			set
			{
				this._description = value;
			}
		}
		
		private int? _partnerID;
		public virtual int? PartnerID
		{
			get
			{
				return this._partnerID;
			}
			set
			{
				this._partnerID = value;
			}
		}
		
		private bool? _activeFlag;
		public virtual bool? ActiveFlag
		{
			get
			{
				return this._activeFlag;
			}
			set
			{
				this._activeFlag = value;
			}
		}
		
		private DateTime? _dateRegistered;
		[DataType(DataType.DateTime)]
		public virtual DateTime? DateRegistered
		{
			get
			{
				return this._dateRegistered;
			}
			set
			{
				this._dateRegistered = value;
			}
		}
		
		private Partner _partner;
		public virtual Partner Partner
		{
			get
			{
				return this._partner;
			}
			set
			{
				this._partner = value;
			}
		}
		
		private IList<OrderDetail> _orderDetails = new List<OrderDetail>();
		public virtual IList<OrderDetail> OrderDetails
		{
			get
			{
				return this._orderDetails;
			}
		}
		
	}
}
#pragma warning restore 1591
