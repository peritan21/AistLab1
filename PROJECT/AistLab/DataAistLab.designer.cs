﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AistLab
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
	
	
	[System.Data.Linq.Mapping.DatabaseAttribute(Name="AIST")]
	public partial class DataAistLabDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertANALIZMENU(ANALIZMENU instance);
    partial void UpdateANALIZMENU(ANALIZMENU instance);
    partial void DeleteANALIZMENU(ANALIZMENU instance);
    #endregion
		
		public DataAistLabDataContext() : 
				base(global::AistLab.Properties.Settings.Default.AISTConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataAistLabDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataAistLabDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataAistLabDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataAistLabDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<ANALIZMENU> ANALIZMENUs
		{
			get
			{
				return this.GetTable<ANALIZMENU>();
			}
		}
		
		public System.Data.Linq.Table<PACIENT_ANALIZ> PACIENT_ANALIZs
		{
			get
			{
				return this.GetTable<PACIENT_ANALIZ>();
			}
		}
		
		[Function(Name="dbo.ANALIZMENU_AddNewR")]
		public ISingleResult<ANALIZMENU_AddNewRResult> ANALIZMENU_AddNewR([Parameter(Name="NAME", DbType="VarChar(200)")] string nAME, [Parameter(Name="Parent_ID", DbType="Int")] System.Nullable<int> parent_ID, [Parameter(Name="TABINDEX", DbType="Int")] System.Nullable<int> tABINDEX)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nAME, parent_ID, tABINDEX);
			return ((ISingleResult<ANALIZMENU_AddNewRResult>)(result.ReturnValue));
		}
		
		[Function(Name="dbo.ANALIZMENU_Delete")]
		public int ANALIZMENU_Delete([Parameter(Name="Analiz_ID", DbType="Int")] System.Nullable<int> analiz_ID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), analiz_ID);
			return ((int)(result.ReturnValue));
		}
		
		[Function(Name="dbo.ANALIZMENU_GET")]
		public ISingleResult<ANALIZMENU_GETResult> ANALIZMENU_GET([Parameter(Name="Analiz_ID", DbType="Int")] System.Nullable<int> analiz_ID, [Parameter(Name="Analiz_Level", DbType="TinyInt")] System.Nullable<byte> analiz_Level)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), analiz_ID, analiz_Level);
			return ((ISingleResult<ANALIZMENU_GETResult>)(result.ReturnValue));
		}
		
		[Function(Name="dbo.ANALIZMENU_UpdateR")]
		public int ANALIZMENU_UpdateR([Parameter(Name="Analiz_ID", DbType="Int")] System.Nullable<int> analiz_ID, [Parameter(Name="NAME", DbType="VarChar(200)")] string nAME, [Parameter(Name="Parent_ID", DbType="Int")] System.Nullable<int> parent_ID, [Parameter(Name="TABINDEX", DbType="Int")] System.Nullable<int> tABINDEX)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), analiz_ID, nAME, parent_ID, tABINDEX);
			return ((int)(result.ReturnValue));
		}
		
		[Function(Name="dbo.PACIENT_ANALIZ_ADD")]
		public ISingleResult<PACIENT_ANALIZ_ADDResult> PACIENT_ANALIZ_ADD([Parameter(DbType="Int")] System.Nullable<int> pacient_id, [Parameter(DbType="DateTime")] System.Nullable<System.DateTime> dataanaliz, [Parameter(DbType="Int")] System.Nullable<int> analiz_type)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pacient_id, dataanaliz, analiz_type);
			return ((ISingleResult<PACIENT_ANALIZ_ADDResult>)(result.ReturnValue));
		}
		
		[Function(Name="dbo.PACIENT_ANALIZ_UPDATE")]
		public int PACIENT_ANALIZ_UPDATE([Parameter(DbType="Int")] System.Nullable<int> analiz_id, [Parameter(DbType="Int")] System.Nullable<int> pacient_id, [Parameter(DbType="DateTime")] System.Nullable<System.DateTime> dataanaliz, [Parameter(DbType="Int")] System.Nullable<int> analiz_type)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), analiz_id, pacient_id, dataanaliz, analiz_type);
			return ((int)(result.ReturnValue));
		}
		
		[Function(Name="dbo.PACIENT_ANALIZDel")]
		public int PACIENT_ANALIZDel([Parameter(DbType="Int")] System.Nullable<int> analiz_id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), analiz_id);
			return ((int)(result.ReturnValue));
		}
	}
	
	[Table(Name="dbo.ANALIZMENU")]
	public partial class ANALIZMENU : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Analiz_ID;
		
		private System.Nullable<byte> _Analiz_Level;
		
		private System.Nullable<int> _Parent_ID;
		
		private string _NAME;
		
		private System.Nullable<int> _TABINDEX;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAnaliz_IDChanging(int value);
    partial void OnAnaliz_IDChanged();
    partial void OnAnaliz_LevelChanging(System.Nullable<byte> value);
    partial void OnAnaliz_LevelChanged();
    partial void OnParent_IDChanging(System.Nullable<int> value);
    partial void OnParent_IDChanged();
    partial void OnNAMEChanging(string value);
    partial void OnNAMEChanged();
    partial void OnTABINDEXChanging(System.Nullable<int> value);
    partial void OnTABINDEXChanged();
    #endregion
		
		public ANALIZMENU()
		{
			OnCreated();
		}
		
		[Column(Storage="_Analiz_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Analiz_ID
		{
			get
			{
				return this._Analiz_ID;
			}
			set
			{
				if ((this._Analiz_ID != value))
				{
					this.OnAnaliz_IDChanging(value);
					this.SendPropertyChanging();
					this._Analiz_ID = value;
					this.SendPropertyChanged("Analiz_ID");
					this.OnAnaliz_IDChanged();
				}
			}
		}
		
		[Column(Storage="_Analiz_Level", DbType="TinyInt")]
		public System.Nullable<byte> Analiz_Level
		{
			get
			{
				return this._Analiz_Level;
			}
			set
			{
				if ((this._Analiz_Level != value))
				{
					this.OnAnaliz_LevelChanging(value);
					this.SendPropertyChanging();
					this._Analiz_Level = value;
					this.SendPropertyChanged("Analiz_Level");
					this.OnAnaliz_LevelChanged();
				}
			}
		}
		
		[Column(Storage="_Parent_ID", DbType="Int")]
		public System.Nullable<int> Parent_ID
		{
			get
			{
				return this._Parent_ID;
			}
			set
			{
				if ((this._Parent_ID != value))
				{
					this.OnParent_IDChanging(value);
					this.SendPropertyChanging();
					this._Parent_ID = value;
					this.SendPropertyChanged("Parent_ID");
					this.OnParent_IDChanged();
				}
			}
		}
		
		[Column(Storage="_NAME", DbType="VarChar(200)")]
		public string NAME
		{
			get
			{
				return this._NAME;
			}
			set
			{
				if ((this._NAME != value))
				{
					this.OnNAMEChanging(value);
					this.SendPropertyChanging();
					this._NAME = value;
					this.SendPropertyChanged("NAME");
					this.OnNAMEChanged();
				}
			}
		}
		
		[Column(Storage="_TABINDEX", DbType="Int")]
		public System.Nullable<int> TABINDEX
		{
			get
			{
				return this._TABINDEX;
			}
			set
			{
				if ((this._TABINDEX != value))
				{
					this.OnTABINDEXChanging(value);
					this.SendPropertyChanging();
					this._TABINDEX = value;
					this.SendPropertyChanged("TABINDEX");
					this.OnTABINDEXChanged();
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
	
	[Table(Name="dbo.PACIENT_ANALIZ")]
	public partial class PACIENT_ANALIZ
	{
		
		private int _analiz_id;
		
		private int _pacient_id;
		
		private System.DateTime _dataanaliz;
		
		private int _analiz_type;
		
		public PACIENT_ANALIZ()
		{
		}
		
		[Column(Storage="_analiz_id", DbType="Int NOT NULL")]
		public int analiz_id
		{
			get
			{
				return this._analiz_id;
			}
			set
			{
				if ((this._analiz_id != value))
				{
					this._analiz_id = value;
				}
			}
		}
		
		[Column(Storage="_pacient_id", DbType="Int NOT NULL")]
		public int pacient_id
		{
			get
			{
				return this._pacient_id;
			}
			set
			{
				if ((this._pacient_id != value))
				{
					this._pacient_id = value;
				}
			}
		}
		
		[Column(Storage="_dataanaliz", DbType="DateTime NOT NULL")]
		public System.DateTime dataanaliz
		{
			get
			{
				return this._dataanaliz;
			}
			set
			{
				if ((this._dataanaliz != value))
				{
					this._dataanaliz = value;
				}
			}
		}
		
		[Column(Storage="_analiz_type", DbType="Int NOT NULL")]
		public int analiz_type
		{
			get
			{
				return this._analiz_type;
			}
			set
			{
				if ((this._analiz_type != value))
				{
					this._analiz_type = value;
				}
			}
		}
	}
	
	public partial class ANALIZMENU_AddNewRResult
	{
		
		private int _Analiz_ID;
		
		private string _NAME;
		
		private System.Nullable<byte> _Analiz_Level;
		
		private System.Nullable<int> _Parent_ID;
		
		private System.Nullable<int> _TABINDEX;
		
		public ANALIZMENU_AddNewRResult()
		{
		}
		
		[Column(Storage="_Analiz_ID", DbType="Int NOT NULL")]
		public int Analiz_ID
		{
			get
			{
				return this._Analiz_ID;
			}
			set
			{
				if ((this._Analiz_ID != value))
				{
					this._Analiz_ID = value;
				}
			}
		}
		
		[Column(Storage="_NAME", DbType="VarChar(200)")]
		public string NAME
		{
			get
			{
				return this._NAME;
			}
			set
			{
				if ((this._NAME != value))
				{
					this._NAME = value;
				}
			}
		}
		
		[Column(Storage="_Analiz_Level", DbType="TinyInt")]
		public System.Nullable<byte> Analiz_Level
		{
			get
			{
				return this._Analiz_Level;
			}
			set
			{
				if ((this._Analiz_Level != value))
				{
					this._Analiz_Level = value;
				}
			}
		}
		
		[Column(Storage="_Parent_ID", DbType="Int")]
		public System.Nullable<int> Parent_ID
		{
			get
			{
				return this._Parent_ID;
			}
			set
			{
				if ((this._Parent_ID != value))
				{
					this._Parent_ID = value;
				}
			}
		}
		
		[Column(Storage="_TABINDEX", DbType="Int")]
		public System.Nullable<int> TABINDEX
		{
			get
			{
				return this._TABINDEX;
			}
			set
			{
				if ((this._TABINDEX != value))
				{
					this._TABINDEX = value;
				}
			}
		}
	}
	
	public partial class ANALIZMENU_GETResult
	{
		
		private System.Nullable<int> _Analiz_ID;
		
		private string _NAME;
		
		private System.Nullable<byte> _Analiz_Level;
		
		private System.Nullable<int> _Parent_ID;
		
		private System.Nullable<int> _TABINDEX;
		
		public ANALIZMENU_GETResult()
		{
		}
		
		[Column(Storage="_Analiz_ID", DbType="Int")]
		public System.Nullable<int> Analiz_ID
		{
			get
			{
				return this._Analiz_ID;
			}
			set
			{
				if ((this._Analiz_ID != value))
				{
					this._Analiz_ID = value;
				}
			}
		}
		
		[Column(Storage="_NAME", DbType="VarChar(200)")]
		public string NAME
		{
			get
			{
				return this._NAME;
			}
			set
			{
				if ((this._NAME != value))
				{
					this._NAME = value;
				}
			}
		}
		
		[Column(Storage="_Analiz_Level", DbType="TinyInt")]
		public System.Nullable<byte> Analiz_Level
		{
			get
			{
				return this._Analiz_Level;
			}
			set
			{
				if ((this._Analiz_Level != value))
				{
					this._Analiz_Level = value;
				}
			}
		}
		
		[Column(Storage="_Parent_ID", DbType="Int")]
		public System.Nullable<int> Parent_ID
		{
			get
			{
				return this._Parent_ID;
			}
			set
			{
				if ((this._Parent_ID != value))
				{
					this._Parent_ID = value;
				}
			}
		}
		
		[Column(Storage="_TABINDEX", DbType="Int")]
		public System.Nullable<int> TABINDEX
		{
			get
			{
				return this._TABINDEX;
			}
			set
			{
				if ((this._TABINDEX != value))
				{
					this._TABINDEX = value;
				}
			}
		}
	}
	
	public partial class PACIENT_ANALIZ_ADDResult
	{
		
		private int _analiz_id;
		
		private int _pacient_id;
		
		private System.DateTime _dataanaliz;
		
		private int _analiz_type;
		
		public PACIENT_ANALIZ_ADDResult()
		{
		}
		
		[Column(Storage="_analiz_id", DbType="Int NOT NULL")]
		public int analiz_id
		{
			get
			{
				return this._analiz_id;
			}
			set
			{
				if ((this._analiz_id != value))
				{
					this._analiz_id = value;
				}
			}
		}
		
		[Column(Storage="_pacient_id", DbType="Int NOT NULL")]
		public int pacient_id
		{
			get
			{
				return this._pacient_id;
			}
			set
			{
				if ((this._pacient_id != value))
				{
					this._pacient_id = value;
				}
			}
		}
		
		[Column(Storage="_dataanaliz", DbType="DateTime NOT NULL")]
		public System.DateTime dataanaliz
		{
			get
			{
				return this._dataanaliz;
			}
			set
			{
				if ((this._dataanaliz != value))
				{
					this._dataanaliz = value;
				}
			}
		}
		
		[Column(Storage="_analiz_type", DbType="Int NOT NULL")]
		public int analiz_type
		{
			get
			{
				return this._analiz_type;
			}
			set
			{
				if ((this._analiz_type != value))
				{
					this._analiz_type = value;
				}
			}
		}
	}
}
#pragma warning restore 1591