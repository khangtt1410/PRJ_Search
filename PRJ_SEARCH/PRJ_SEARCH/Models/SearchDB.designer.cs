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

namespace PRJ_SEARCH
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SearchDB")]
	public partial class SearchDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Inserttb_NgonNgu(tb_NgonNgu instance);
    partial void Updatetb_NgonNgu(tb_NgonNgu instance);
    partial void Deletetb_NgonNgu(tb_NgonNgu instance);
    partial void Inserttb_TuNgu(tb_TuNgu instance);
    partial void Updatetb_TuNgu(tb_TuNgu instance);
    partial void Deletetb_TuNgu(tb_TuNgu instance);
    partial void Inserttb_NguoiDung(tb_NguoiDung instance);
    partial void Updatetb_NguoiDung(tb_NguoiDung instance);
    partial void Deletetb_NguoiDung(tb_NguoiDung instance);
    partial void Inserttb_TuDien(tb_TuDien instance);
    partial void Updatetb_TuDien(tb_TuDien instance);
    partial void Deletetb_TuDien(tb_TuDien instance);
    #endregion
		
		public SearchDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SearchDBConnectionString1"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SearchDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SearchDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SearchDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SearchDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tb_NgonNgu> tb_NgonNgus
		{
			get
			{
				return this.GetTable<tb_NgonNgu>();
			}
		}
		
		public System.Data.Linq.Table<tb_TuNgu> tb_TuNgus
		{
			get
			{
				return this.GetTable<tb_TuNgu>();
			}
		}
		
		public System.Data.Linq.Table<tb_NguoiDung> tb_NguoiDungs
		{
			get
			{
				return this.GetTable<tb_NguoiDung>();
			}
		}
		
		public System.Data.Linq.Table<tb_TuDien> tb_TuDiens
		{
			get
			{
				return this.GetTable<tb_TuDien>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tb_NgonNgu")]
	public partial class tb_NgonNgu : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _TenNgonNgu;
		
		private System.Nullable<bool> _TrangThai;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<int> _NguoiTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		private System.Nullable<int> _NguoiSua;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnTenNgonNguChanging(string value);
    partial void OnTenNgonNguChanged();
    partial void OnTrangThaiChanging(System.Nullable<bool> value);
    partial void OnTrangThaiChanged();
    partial void OnNgayTaoChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayTaoChanged();
    partial void OnNguoiTaoChanging(System.Nullable<int> value);
    partial void OnNguoiTaoChanged();
    partial void OnNgaySuaChanging(System.Nullable<System.DateTime> value);
    partial void OnNgaySuaChanged();
    partial void OnNguoiSuaChanging(System.Nullable<int> value);
    partial void OnNguoiSuaChanged();
    #endregion
		
		public tb_NgonNgu()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenNgonNgu", DbType="NVarChar(500)")]
		public string TenNgonNgu
		{
			get
			{
				return this._TenNgonNgu;
			}
			set
			{
				if ((this._TenNgonNgu != value))
				{
					this.OnTenNgonNguChanging(value);
					this.SendPropertyChanging();
					this._TenNgonNgu = value;
					this.SendPropertyChanged("TenNgonNgu");
					this.OnTenNgonNguChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrangThai", DbType="Bit")]
		public System.Nullable<bool> TrangThai
		{
			get
			{
				return this._TrangThai;
			}
			set
			{
				if ((this._TrangThai != value))
				{
					this.OnTrangThaiChanging(value);
					this.SendPropertyChanging();
					this._TrangThai = value;
					this.SendPropertyChanged("TrangThai");
					this.OnTrangThaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayTao", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayTao
		{
			get
			{
				return this._NgayTao;
			}
			set
			{
				if ((this._NgayTao != value))
				{
					this.OnNgayTaoChanging(value);
					this.SendPropertyChanging();
					this._NgayTao = value;
					this.SendPropertyChanged("NgayTao");
					this.OnNgayTaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiTao", DbType="Int")]
		public System.Nullable<int> NguoiTao
		{
			get
			{
				return this._NguoiTao;
			}
			set
			{
				if ((this._NguoiTao != value))
				{
					this.OnNguoiTaoChanging(value);
					this.SendPropertyChanging();
					this._NguoiTao = value;
					this.SendPropertyChanged("NguoiTao");
					this.OnNguoiTaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgaySua", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgaySua
		{
			get
			{
				return this._NgaySua;
			}
			set
			{
				if ((this._NgaySua != value))
				{
					this.OnNgaySuaChanging(value);
					this.SendPropertyChanging();
					this._NgaySua = value;
					this.SendPropertyChanged("NgaySua");
					this.OnNgaySuaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiSua", DbType="Int")]
		public System.Nullable<int> NguoiSua
		{
			get
			{
				return this._NguoiSua;
			}
			set
			{
				if ((this._NguoiSua != value))
				{
					this.OnNguoiSuaChanging(value);
					this.SendPropertyChanging();
					this._NguoiSua = value;
					this.SendPropertyChanged("NguoiSua");
					this.OnNguoiSuaChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tb_TuNgu")]
	public partial class tb_TuNgu : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.Nullable<int> _IDTuDien;
		
		private string _NoiDungTu;
		
		private string _NghiaCuaTu;
		
		private string _TuDongNghia;
		
		private string _TuTraiNghia;
		
		private System.Nullable<int> _IDNgonNgu;
		
		private string _ThanhNgu;
		
		private string _ViDu;
		
		private string _CumDongTu;
		
		private string _TuLienQuan;
		
		private System.Nullable<bool> _TrangThai;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<int> _NguoiTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		private System.Nullable<int> _NguoiSua;
		
		private string _TuDichNghia;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnIDTuDienChanging(System.Nullable<int> value);
    partial void OnIDTuDienChanged();
    partial void OnNoiDungTuChanging(string value);
    partial void OnNoiDungTuChanged();
    partial void OnNghiaCuaTuChanging(string value);
    partial void OnNghiaCuaTuChanged();
    partial void OnTuDongNghiaChanging(string value);
    partial void OnTuDongNghiaChanged();
    partial void OnTuTraiNghiaChanging(string value);
    partial void OnTuTraiNghiaChanged();
    partial void OnIDNgonNguChanging(System.Nullable<int> value);
    partial void OnIDNgonNguChanged();
    partial void OnThanhNguChanging(string value);
    partial void OnThanhNguChanged();
    partial void OnViDuChanging(string value);
    partial void OnViDuChanged();
    partial void OnCumDongTuChanging(string value);
    partial void OnCumDongTuChanged();
    partial void OnTuLienQuanChanging(string value);
    partial void OnTuLienQuanChanged();
    partial void OnTrangThaiChanging(System.Nullable<bool> value);
    partial void OnTrangThaiChanged();
    partial void OnNgayTaoChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayTaoChanged();
    partial void OnNguoiTaoChanging(System.Nullable<int> value);
    partial void OnNguoiTaoChanged();
    partial void OnNgaySuaChanging(System.Nullable<System.DateTime> value);
    partial void OnNgaySuaChanged();
    partial void OnNguoiSuaChanging(System.Nullable<int> value);
    partial void OnNguoiSuaChanged();
    partial void OnTuDichNghiaChanging(string value);
    partial void OnTuDichNghiaChanged();
    #endregion
		
		public tb_TuNgu()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDTuDien", DbType="Int")]
		public System.Nullable<int> IDTuDien
		{
			get
			{
				return this._IDTuDien;
			}
			set
			{
				if ((this._IDTuDien != value))
				{
					this.OnIDTuDienChanging(value);
					this.SendPropertyChanging();
					this._IDTuDien = value;
					this.SendPropertyChanged("IDTuDien");
					this.OnIDTuDienChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NoiDungTu", DbType="NVarChar(MAX)")]
		public string NoiDungTu
		{
			get
			{
				return this._NoiDungTu;
			}
			set
			{
				if ((this._NoiDungTu != value))
				{
					this.OnNoiDungTuChanging(value);
					this.SendPropertyChanging();
					this._NoiDungTu = value;
					this.SendPropertyChanged("NoiDungTu");
					this.OnNoiDungTuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NghiaCuaTu", DbType="NVarChar(MAX)")]
		public string NghiaCuaTu
		{
			get
			{
				return this._NghiaCuaTu;
			}
			set
			{
				if ((this._NghiaCuaTu != value))
				{
					this.OnNghiaCuaTuChanging(value);
					this.SendPropertyChanging();
					this._NghiaCuaTu = value;
					this.SendPropertyChanged("NghiaCuaTu");
					this.OnNghiaCuaTuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TuDongNghia", DbType="NVarChar(MAX)")]
		public string TuDongNghia
		{
			get
			{
				return this._TuDongNghia;
			}
			set
			{
				if ((this._TuDongNghia != value))
				{
					this.OnTuDongNghiaChanging(value);
					this.SendPropertyChanging();
					this._TuDongNghia = value;
					this.SendPropertyChanged("TuDongNghia");
					this.OnTuDongNghiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TuTraiNghia", DbType="NVarChar(MAX)")]
		public string TuTraiNghia
		{
			get
			{
				return this._TuTraiNghia;
			}
			set
			{
				if ((this._TuTraiNghia != value))
				{
					this.OnTuTraiNghiaChanging(value);
					this.SendPropertyChanging();
					this._TuTraiNghia = value;
					this.SendPropertyChanged("TuTraiNghia");
					this.OnTuTraiNghiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNgonNgu", DbType="Int")]
		public System.Nullable<int> IDNgonNgu
		{
			get
			{
				return this._IDNgonNgu;
			}
			set
			{
				if ((this._IDNgonNgu != value))
				{
					this.OnIDNgonNguChanging(value);
					this.SendPropertyChanging();
					this._IDNgonNgu = value;
					this.SendPropertyChanged("IDNgonNgu");
					this.OnIDNgonNguChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThanhNgu", DbType="NVarChar(MAX)")]
		public string ThanhNgu
		{
			get
			{
				return this._ThanhNgu;
			}
			set
			{
				if ((this._ThanhNgu != value))
				{
					this.OnThanhNguChanging(value);
					this.SendPropertyChanging();
					this._ThanhNgu = value;
					this.SendPropertyChanged("ThanhNgu");
					this.OnThanhNguChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ViDu", DbType="NVarChar(MAX)")]
		public string ViDu
		{
			get
			{
				return this._ViDu;
			}
			set
			{
				if ((this._ViDu != value))
				{
					this.OnViDuChanging(value);
					this.SendPropertyChanging();
					this._ViDu = value;
					this.SendPropertyChanged("ViDu");
					this.OnViDuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CumDongTu", DbType="NVarChar(MAX)")]
		public string CumDongTu
		{
			get
			{
				return this._CumDongTu;
			}
			set
			{
				if ((this._CumDongTu != value))
				{
					this.OnCumDongTuChanging(value);
					this.SendPropertyChanging();
					this._CumDongTu = value;
					this.SendPropertyChanged("CumDongTu");
					this.OnCumDongTuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TuLienQuan", DbType="NVarChar(MAX)")]
		public string TuLienQuan
		{
			get
			{
				return this._TuLienQuan;
			}
			set
			{
				if ((this._TuLienQuan != value))
				{
					this.OnTuLienQuanChanging(value);
					this.SendPropertyChanging();
					this._TuLienQuan = value;
					this.SendPropertyChanged("TuLienQuan");
					this.OnTuLienQuanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrangThai", DbType="Bit")]
		public System.Nullable<bool> TrangThai
		{
			get
			{
				return this._TrangThai;
			}
			set
			{
				if ((this._TrangThai != value))
				{
					this.OnTrangThaiChanging(value);
					this.SendPropertyChanging();
					this._TrangThai = value;
					this.SendPropertyChanged("TrangThai");
					this.OnTrangThaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayTao", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayTao
		{
			get
			{
				return this._NgayTao;
			}
			set
			{
				if ((this._NgayTao != value))
				{
					this.OnNgayTaoChanging(value);
					this.SendPropertyChanging();
					this._NgayTao = value;
					this.SendPropertyChanged("NgayTao");
					this.OnNgayTaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiTao", DbType="Int")]
		public System.Nullable<int> NguoiTao
		{
			get
			{
				return this._NguoiTao;
			}
			set
			{
				if ((this._NguoiTao != value))
				{
					this.OnNguoiTaoChanging(value);
					this.SendPropertyChanging();
					this._NguoiTao = value;
					this.SendPropertyChanged("NguoiTao");
					this.OnNguoiTaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgaySua", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgaySua
		{
			get
			{
				return this._NgaySua;
			}
			set
			{
				if ((this._NgaySua != value))
				{
					this.OnNgaySuaChanging(value);
					this.SendPropertyChanging();
					this._NgaySua = value;
					this.SendPropertyChanged("NgaySua");
					this.OnNgaySuaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiSua", DbType="Int")]
		public System.Nullable<int> NguoiSua
		{
			get
			{
				return this._NguoiSua;
			}
			set
			{
				if ((this._NguoiSua != value))
				{
					this.OnNguoiSuaChanging(value);
					this.SendPropertyChanging();
					this._NguoiSua = value;
					this.SendPropertyChanged("NguoiSua");
					this.OnNguoiSuaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TuDichNghia", DbType="NVarChar(MAX)")]
		public string TuDichNghia
		{
			get
			{
				return this._TuDichNghia;
			}
			set
			{
				if ((this._TuDichNghia != value))
				{
					this.OnTuDichNghiaChanging(value);
					this.SendPropertyChanging();
					this._TuDichNghia = value;
					this.SendPropertyChanged("TuDichNghia");
					this.OnTuDichNghiaChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tb_NguoiDung")]
	public partial class tb_NguoiDung : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _TenDangNhap;
		
		private string _MatKhau;
		
		private string _HoTen;
		
		private string _DiaChi;
		
		private string _SoDienThoai;
		
		private string _Email;
		
		private System.Nullable<bool> _TrangThai;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<int> _NguoiTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		private System.Nullable<int> _NguoiSua;
		
		private string _DoPhucTap;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnTenDangNhapChanging(string value);
    partial void OnTenDangNhapChanged();
    partial void OnMatKhauChanging(string value);
    partial void OnMatKhauChanged();
    partial void OnHoTenChanging(string value);
    partial void OnHoTenChanged();
    partial void OnDiaChiChanging(string value);
    partial void OnDiaChiChanged();
    partial void OnSoDienThoaiChanging(string value);
    partial void OnSoDienThoaiChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnTrangThaiChanging(System.Nullable<bool> value);
    partial void OnTrangThaiChanged();
    partial void OnNgayTaoChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayTaoChanged();
    partial void OnNguoiTaoChanging(System.Nullable<int> value);
    partial void OnNguoiTaoChanged();
    partial void OnNgaySuaChanging(System.Nullable<System.DateTime> value);
    partial void OnNgaySuaChanged();
    partial void OnNguoiSuaChanging(System.Nullable<int> value);
    partial void OnNguoiSuaChanged();
    partial void OnDoPhucTapChanging(string value);
    partial void OnDoPhucTapChanged();
    #endregion
		
		public tb_NguoiDung()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenDangNhap", DbType="NVarChar(50)")]
		public string TenDangNhap
		{
			get
			{
				return this._TenDangNhap;
			}
			set
			{
				if ((this._TenDangNhap != value))
				{
					this.OnTenDangNhapChanging(value);
					this.SendPropertyChanging();
					this._TenDangNhap = value;
					this.SendPropertyChanged("TenDangNhap");
					this.OnTenDangNhapChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MatKhau", DbType="VarChar(50)")]
		public string MatKhau
		{
			get
			{
				return this._MatKhau;
			}
			set
			{
				if ((this._MatKhau != value))
				{
					this.OnMatKhauChanging(value);
					this.SendPropertyChanging();
					this._MatKhau = value;
					this.SendPropertyChanged("MatKhau");
					this.OnMatKhauChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoTen", DbType="NVarChar(250)")]
		public string HoTen
		{
			get
			{
				return this._HoTen;
			}
			set
			{
				if ((this._HoTen != value))
				{
					this.OnHoTenChanging(value);
					this.SendPropertyChanging();
					this._HoTen = value;
					this.SendPropertyChanged("HoTen");
					this.OnHoTenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChi", DbType="NVarChar(1500)")]
		public string DiaChi
		{
			get
			{
				return this._DiaChi;
			}
			set
			{
				if ((this._DiaChi != value))
				{
					this.OnDiaChiChanging(value);
					this.SendPropertyChanging();
					this._DiaChi = value;
					this.SendPropertyChanged("DiaChi");
					this.OnDiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoDienThoai", DbType="NVarChar(50)")]
		public string SoDienThoai
		{
			get
			{
				return this._SoDienThoai;
			}
			set
			{
				if ((this._SoDienThoai != value))
				{
					this.OnSoDienThoaiChanging(value);
					this.SendPropertyChanging();
					this._SoDienThoai = value;
					this.SendPropertyChanged("SoDienThoai");
					this.OnSoDienThoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(500)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrangThai", DbType="Bit")]
		public System.Nullable<bool> TrangThai
		{
			get
			{
				return this._TrangThai;
			}
			set
			{
				if ((this._TrangThai != value))
				{
					this.OnTrangThaiChanging(value);
					this.SendPropertyChanging();
					this._TrangThai = value;
					this.SendPropertyChanged("TrangThai");
					this.OnTrangThaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayTao", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayTao
		{
			get
			{
				return this._NgayTao;
			}
			set
			{
				if ((this._NgayTao != value))
				{
					this.OnNgayTaoChanging(value);
					this.SendPropertyChanging();
					this._NgayTao = value;
					this.SendPropertyChanged("NgayTao");
					this.OnNgayTaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiTao", DbType="Int")]
		public System.Nullable<int> NguoiTao
		{
			get
			{
				return this._NguoiTao;
			}
			set
			{
				if ((this._NguoiTao != value))
				{
					this.OnNguoiTaoChanging(value);
					this.SendPropertyChanging();
					this._NguoiTao = value;
					this.SendPropertyChanged("NguoiTao");
					this.OnNguoiTaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgaySua", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgaySua
		{
			get
			{
				return this._NgaySua;
			}
			set
			{
				if ((this._NgaySua != value))
				{
					this.OnNgaySuaChanging(value);
					this.SendPropertyChanging();
					this._NgaySua = value;
					this.SendPropertyChanged("NgaySua");
					this.OnNgaySuaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiSua", DbType="Int")]
		public System.Nullable<int> NguoiSua
		{
			get
			{
				return this._NguoiSua;
			}
			set
			{
				if ((this._NguoiSua != value))
				{
					this.OnNguoiSuaChanging(value);
					this.SendPropertyChanging();
					this._NguoiSua = value;
					this.SendPropertyChanged("NguoiSua");
					this.OnNguoiSuaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DoPhucTap", DbType="NVarChar(50)")]
		public string DoPhucTap
		{
			get
			{
				return this._DoPhucTap;
			}
			set
			{
				if ((this._DoPhucTap != value))
				{
					this.OnDoPhucTapChanging(value);
					this.SendPropertyChanging();
					this._DoPhucTap = value;
					this.SendPropertyChanged("DoPhucTap");
					this.OnDoPhucTapChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tb_TuDien")]
	public partial class tb_TuDien : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _TenTuDien;
		
		private string _MaTuDien;
		
		private string _TacGia;
		
		private System.Nullable<int> _IDNgonNguNguon;
		
		private System.Nullable<int> _IDNgonNguDich;
		
		private System.Nullable<bool> _TrangThai;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<int> _NguoiTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		private System.Nullable<int> _NguoiSua;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnTenTuDienChanging(string value);
    partial void OnTenTuDienChanged();
    partial void OnMaTuDienChanging(string value);
    partial void OnMaTuDienChanged();
    partial void OnTacGiaChanging(string value);
    partial void OnTacGiaChanged();
    partial void OnIDNgonNguNguonChanging(System.Nullable<int> value);
    partial void OnIDNgonNguNguonChanged();
    partial void OnIDNgonNguDichChanging(System.Nullable<int> value);
    partial void OnIDNgonNguDichChanged();
    partial void OnTrangThaiChanging(System.Nullable<bool> value);
    partial void OnTrangThaiChanged();
    partial void OnNgayTaoChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayTaoChanged();
    partial void OnNguoiTaoChanging(System.Nullable<int> value);
    partial void OnNguoiTaoChanged();
    partial void OnNgaySuaChanging(System.Nullable<System.DateTime> value);
    partial void OnNgaySuaChanged();
    partial void OnNguoiSuaChanging(System.Nullable<int> value);
    partial void OnNguoiSuaChanged();
    #endregion
		
		public tb_TuDien()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenTuDien", DbType="NVarChar(2500)")]
		public string TenTuDien
		{
			get
			{
				return this._TenTuDien;
			}
			set
			{
				if ((this._TenTuDien != value))
				{
					this.OnTenTuDienChanging(value);
					this.SendPropertyChanging();
					this._TenTuDien = value;
					this.SendPropertyChanged("TenTuDien");
					this.OnTenTuDienChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaTuDien", DbType="NVarChar(50)")]
		public string MaTuDien
		{
			get
			{
				return this._MaTuDien;
			}
			set
			{
				if ((this._MaTuDien != value))
				{
					this.OnMaTuDienChanging(value);
					this.SendPropertyChanging();
					this._MaTuDien = value;
					this.SendPropertyChanged("MaTuDien");
					this.OnMaTuDienChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TacGia", DbType="NVarChar(250)")]
		public string TacGia
		{
			get
			{
				return this._TacGia;
			}
			set
			{
				if ((this._TacGia != value))
				{
					this.OnTacGiaChanging(value);
					this.SendPropertyChanging();
					this._TacGia = value;
					this.SendPropertyChanged("TacGia");
					this.OnTacGiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNgonNguNguon", DbType="Int")]
		public System.Nullable<int> IDNgonNguNguon
		{
			get
			{
				return this._IDNgonNguNguon;
			}
			set
			{
				if ((this._IDNgonNguNguon != value))
				{
					this.OnIDNgonNguNguonChanging(value);
					this.SendPropertyChanging();
					this._IDNgonNguNguon = value;
					this.SendPropertyChanged("IDNgonNguNguon");
					this.OnIDNgonNguNguonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNgonNguDich", DbType="Int")]
		public System.Nullable<int> IDNgonNguDich
		{
			get
			{
				return this._IDNgonNguDich;
			}
			set
			{
				if ((this._IDNgonNguDich != value))
				{
					this.OnIDNgonNguDichChanging(value);
					this.SendPropertyChanging();
					this._IDNgonNguDich = value;
					this.SendPropertyChanged("IDNgonNguDich");
					this.OnIDNgonNguDichChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrangThai", DbType="Bit")]
		public System.Nullable<bool> TrangThai
		{
			get
			{
				return this._TrangThai;
			}
			set
			{
				if ((this._TrangThai != value))
				{
					this.OnTrangThaiChanging(value);
					this.SendPropertyChanging();
					this._TrangThai = value;
					this.SendPropertyChanged("TrangThai");
					this.OnTrangThaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayTao", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayTao
		{
			get
			{
				return this._NgayTao;
			}
			set
			{
				if ((this._NgayTao != value))
				{
					this.OnNgayTaoChanging(value);
					this.SendPropertyChanging();
					this._NgayTao = value;
					this.SendPropertyChanged("NgayTao");
					this.OnNgayTaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiTao", DbType="Int")]
		public System.Nullable<int> NguoiTao
		{
			get
			{
				return this._NguoiTao;
			}
			set
			{
				if ((this._NguoiTao != value))
				{
					this.OnNguoiTaoChanging(value);
					this.SendPropertyChanging();
					this._NguoiTao = value;
					this.SendPropertyChanged("NguoiTao");
					this.OnNguoiTaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgaySua", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgaySua
		{
			get
			{
				return this._NgaySua;
			}
			set
			{
				if ((this._NgaySua != value))
				{
					this.OnNgaySuaChanging(value);
					this.SendPropertyChanging();
					this._NgaySua = value;
					this.SendPropertyChanged("NgaySua");
					this.OnNgaySuaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiSua", DbType="Int")]
		public System.Nullable<int> NguoiSua
		{
			get
			{
				return this._NguoiSua;
			}
			set
			{
				if ((this._NguoiSua != value))
				{
					this.OnNguoiSuaChanging(value);
					this.SendPropertyChanging();
					this._NguoiSua = value;
					this.SendPropertyChanged("NguoiSua");
					this.OnNguoiSuaChanged();
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
