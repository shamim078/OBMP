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
	public partial class Order
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
		
		private DateTime? _orderDate;
		[DataType(DataType.DateTime)]
		public virtual DateTime? OrderDate
		{
			get
			{
				return this._orderDate;
			}
			set
			{
				this._orderDate = value;
			}
		}
		
		private DateTime? _dueDate;
		[DataType(DataType.DateTime)]
		public virtual DateTime? DueDate
		{
			get
			{
				return this._dueDate;
			}
			set
			{
				this._dueDate = value;
			}
		}
		
		private int? _status;
		public virtual int? Status
		{
			get
			{
				return this._status;
			}
			set
			{
				this._status = value;
			}
		}
		
		private long? _totalSaleAmount;
		public virtual long? TotalSaleAmount
		{
			get
			{
				return this._totalSaleAmount;
			}
			set
			{
				this._totalSaleAmount = value;
			}
		}
		
		private long? _customerID;
		public virtual long? CustomerID
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
		
		private int? _salesPersonID;
		public virtual int? SalesPersonID
		{
			get
			{
				return this._salesPersonID;
			}
			set
			{
				this._salesPersonID = value;
			}
		}
		
		private DateTime? _modificationDate;
		[DataType(DataType.DateTime)]
		public virtual DateTime? ModificationDate
		{
			get
			{
				return this._modificationDate;
			}
			set
			{
				this._modificationDate = value;
			}
		}
		
		private int? _optusStatus;
		public virtual int? OptusStatus
		{
			get
			{
				return this._optusStatus;
			}
			set
			{
				this._optusStatus = value;
			}
		}
		
		private int? _optusUpdatedBy;
		public virtual int? OptusUpdatedBy
		{
			get
			{
				return this._optusUpdatedBy;
			}
			set
			{
				this._optusUpdatedBy = value;
			}
		}
		
		private DateTime? _optusUpdateDate;
		[DataType(DataType.DateTime)]
		public virtual DateTime? OptusUpdateDate
		{
			get
			{
				return this._optusUpdateDate;
			}
			set
			{
				this._optusUpdateDate = value;
			}
		}
		
		private int? _partnerStatus;
		public virtual int? PartnerStatus
		{
			get
			{
				return this._partnerStatus;
			}
			set
			{
				this._partnerStatus = value;
			}
		}
		
		private int? _partnerUpdatedBy;
		public virtual int? PartnerUpdatedBy
		{
			get
			{
				return this._partnerUpdatedBy;
			}
			set
			{
				this._partnerUpdatedBy = value;
			}
		}
		
		private DateTime? _partnerUpdateDate;
		[DataType(DataType.DateTime)]
		public virtual DateTime? PartnerUpdateDate
		{
			get
			{
				return this._partnerUpdateDate;
			}
			set
			{
				this._partnerUpdateDate = value;
			}
		}
		
		private int? _customerStatus;
		public virtual int? CustomerStatus
		{
			get
			{
				return this._customerStatus;
			}
			set
			{
				this._customerStatus = value;
			}
		}
		
		private int? _customerUpdatedBy;
		public virtual int? CustomerUpdatedBy
		{
			get
			{
				return this._customerUpdatedBy;
			}
			set
			{
				this._customerUpdatedBy = value;
			}
		}
		
		private DateTime? _customerUpdateDate;
		[DataType(DataType.DateTime)]
		public virtual DateTime? CustomerUpdateDate
		{
			get
			{
				return this._customerUpdateDate;
			}
			set
			{
				this._customerUpdateDate = value;
			}
		}
		
		private IList<Payment> _payments = new List<Payment>();
		public virtual IList<Payment> Payments
		{
			get
			{
				return this._payments;
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
		
		private Customer _customer;
		public virtual Customer Customer
		{
			get
			{
				return this._customer;
			}
			set
			{
				this._customer = value;
			}
		}
		
		private IList<Billing> _billings = new List<Billing>();
		public virtual IList<Billing> Billings
		{
			get
			{
				return this._billings;
			}
		}
		
	}
}
#pragma warning restore 1591
