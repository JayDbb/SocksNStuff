﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SocksNStuff
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SocksNStuff")]
	public partial class CustomerDataClassDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCustomer(Customer instance);
    partial void UpdateCustomer(Customer instance);
    partial void DeleteCustomer(Customer instance);
    #endregion
		
		public CustomerDataClassDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CustomerDataClassDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CustomerDataClassDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CustomerDataClassDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Customer> Customers
		{
			get
			{
				return this.GetTable<Customer>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customers")]
	public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Fname;
		
		private string _Lname;
		
		private string _Address;
		
		private string _Email;
		
		private string _Password;
		
		private System.Nullable<System.DateTime> _CreatedAt;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFnameChanging(string value);
    partial void OnFnameChanged();
    partial void OnLnameChanging(string value);
    partial void OnLnameChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnCreatedAtChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedAtChanged();
    #endregion
		
		public Customer()
		{
			OnCreated();
		}

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_Id", DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if ((this._Id != value))
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }


        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fname", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Fname
		{
			get
			{
				return this._Fname;
			}
			set
			{
				if ((this._Fname != value))
				{
					this.OnFnameChanging(value);
					this.SendPropertyChanging();
					this._Fname = value;
					this.SendPropertyChanged("Fname");
					this.OnFnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Lname", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Lname
		{
			get
			{
				return this._Lname;
			}
			set
			{
				if ((this._Lname != value))
				{
					this.OnLnameChanging(value);
					this.SendPropertyChanging();
					this._Lname = value;
					this.SendPropertyChanged("Lname");
					this.OnLnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(50)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedAt", DbType="Date")]
		public System.Nullable<System.DateTime> CreatedAt
		{
			get
			{
				return this._CreatedAt;
			}
			set
			{
				if ((this._CreatedAt != value))
				{
					this.OnCreatedAtChanging(value);
					this.SendPropertyChanging();
					this._CreatedAt = value;
					this.SendPropertyChanged("CreatedAt");
					this.OnCreatedAtChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
