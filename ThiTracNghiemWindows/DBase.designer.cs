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

namespace ThiTracNghiemWindows
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PMTHI")]
	public partial class DBaseDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSINHVIEN(SINHVIEN instance);
    partial void UpdateSINHVIEN(SINHVIEN instance);
    partial void DeleteSINHVIEN(SINHVIEN instance);
    #endregion
		
		public DBaseDataContext() : 
				base(global::ThiTracNghiemWindows.Properties.Settings.Default.PMTHIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DBaseDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBaseDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBaseDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBaseDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<SINHVIEN> SINHVIENs
		{
			get
			{
				return this.GetTable<SINHVIEN>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SINHVIEN")]
	public partial class SINHVIEN : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MASV;
		
		private string _ID;
		
		private string _HOTEN;
		
		private System.Nullable<System.DateTime> _NGSINH;
		
		private string _DCHI;
		
		private string _GIOITINH;
		
		private string _HINH;
		
		private string _MALOP;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMASVChanging(string value);
    partial void OnMASVChanged();
    partial void OnIDChanging(string value);
    partial void OnIDChanged();
    partial void OnHOTENChanging(string value);
    partial void OnHOTENChanged();
    partial void OnNGSINHChanging(System.Nullable<System.DateTime> value);
    partial void OnNGSINHChanged();
    partial void OnDCHIChanging(string value);
    partial void OnDCHIChanged();
    partial void OnGIOITINHChanging(string value);
    partial void OnGIOITINHChanged();
    partial void OnHINHChanging(string value);
    partial void OnHINHChanged();
    partial void OnMALOPChanging(string value);
    partial void OnMALOPChanged();
    #endregion
		
		public SINHVIEN()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MASV", DbType="VarChar(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MASV
		{
			get
			{
				return this._MASV;
			}
			set
			{
				if ((this._MASV != value))
				{
					this.OnMASVChanging(value);
					this.SendPropertyChanging();
					this._MASV = value;
					this.SendPropertyChanged("MASV");
					this.OnMASVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="NVarChar(20)")]
		public string ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HOTEN", DbType="NVarChar(50)")]
		public string HOTEN
		{
			get
			{
				return this._HOTEN;
			}
			set
			{
				if ((this._HOTEN != value))
				{
					this.OnHOTENChanging(value);
					this.SendPropertyChanging();
					this._HOTEN = value;
					this.SendPropertyChanged("HOTEN");
					this.OnHOTENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGSINH", DbType="Date")]
		public System.Nullable<System.DateTime> NGSINH
		{
			get
			{
				return this._NGSINH;
			}
			set
			{
				if ((this._NGSINH != value))
				{
					this.OnNGSINHChanging(value);
					this.SendPropertyChanging();
					this._NGSINH = value;
					this.SendPropertyChanged("NGSINH");
					this.OnNGSINHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DCHI", DbType="NVarChar(MAX)")]
		public string DCHI
		{
			get
			{
				return this._DCHI;
			}
			set
			{
				if ((this._DCHI != value))
				{
					this.OnDCHIChanging(value);
					this.SendPropertyChanging();
					this._DCHI = value;
					this.SendPropertyChanged("DCHI");
					this.OnDCHIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GIOITINH", DbType="NVarChar(10)")]
		public string GIOITINH
		{
			get
			{
				return this._GIOITINH;
			}
			set
			{
				if ((this._GIOITINH != value))
				{
					this.OnGIOITINHChanging(value);
					this.SendPropertyChanging();
					this._GIOITINH = value;
					this.SendPropertyChanged("GIOITINH");
					this.OnGIOITINHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HINH", DbType="VarChar(MAX)")]
		public string HINH
		{
			get
			{
				return this._HINH;
			}
			set
			{
				if ((this._HINH != value))
				{
					this.OnHINHChanging(value);
					this.SendPropertyChanging();
					this._HINH = value;
					this.SendPropertyChanged("HINH");
					this.OnHINHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MALOP", DbType="VarChar(20)")]
		public string MALOP
		{
			get
			{
				return this._MALOP;
			}
			set
			{
				if ((this._MALOP != value))
				{
					this.OnMALOPChanging(value);
					this.SendPropertyChanging();
					this._MALOP = value;
					this.SendPropertyChanged("MALOP");
					this.OnMALOPChanged();
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
