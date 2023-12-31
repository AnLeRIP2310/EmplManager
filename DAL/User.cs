using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;
using SubSonic.Utilities;
// <auto-generated />
namespace DAL
{
    /// <summary>
    /// Strongly-typed collection for the User class.
    /// </summary>
    [Serializable]
    public partial class UserCollection : ActiveList<User, UserCollection>
    {
        public UserCollection() { }

        /// <summary>
        /// Filters an existing collection based on the set criteria. This is an in-memory filter
        /// Thanks to developingchris for this!
        /// </summary>
        /// <returns>UserCollection</returns>
        public UserCollection Filter()
        {
            for (int i = this.Count - 1; i > -1; i--)
            {
                User o = this[i];
                foreach (SubSonic.Where w in this.wheres)
                {
                    bool remove = false;
                    System.Reflection.PropertyInfo pi = o.GetType().GetProperty(w.ColumnName);
                    if (pi.CanRead)
                    {
                        object val = pi.GetValue(o, null);
                        switch (w.Comparison)
                        {
                            case SubSonic.Comparison.Equals:
                                if (!val.Equals(w.ParameterValue))
                                {
                                    remove = true;
                                }
                                break;
                        }
                    }
                    if (remove)
                    {
                        this.Remove(o);
                        break;
                    }
                }
            }
            return this;
        }


    }
    /// <summary>
    /// This is an ActiveRecord class which wraps the Users table.
    /// </summary>
    [Serializable]
    public partial class User : ActiveRecord<User>, IActiveRecord
    {
        #region .ctors and Default Settings

        public User()
        {
            SetSQLProps();
            InitSetDefaults();
            MarkNew();
        }

        private void InitSetDefaults() { SetDefaults(); }

        public User(bool useDatabaseDefaults)
        {
            SetSQLProps();
            if (useDatabaseDefaults)
                ForceDefaults();
            MarkNew();
        }

        public User(object keyID)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByKey(keyID);
        }

        public User(string columnName, object columnValue)
        {
            SetSQLProps();
            InitSetDefaults();
            LoadByParam(columnName, columnValue);
        }

        protected static void SetSQLProps() { GetTableSchema(); }

        #endregion

        #region Schema and Query Accessor	
        public static Query CreateQuery() { return new Query(Schema); }
        public static TableSchema.Table Schema
        {
            get
            {
                if (BaseSchema == null)
                    SetSQLProps();
                return BaseSchema;
            }
        }

        private static void GetTableSchema()
        {
            if (!IsSchemaInitialized)
            {
                //Schema declaration
                TableSchema.Table schema = new TableSchema.Table("Users", TableType.Table, DataService.GetInstance("MyDAL"));
                schema.Columns = new TableSchema.TableColumnCollection();
                schema.SchemaName = @"dbo";
                //columns

                TableSchema.TableColumn colvarId = new TableSchema.TableColumn(schema);
                colvarId.ColumnName = "Id";
                colvarId.DataType = DbType.Int32;
                colvarId.MaxLength = 0;
                colvarId.AutoIncrement = true;
                colvarId.IsNullable = false;
                colvarId.IsPrimaryKey = true;
                colvarId.IsForeignKey = false;
                colvarId.IsReadOnly = false;
                colvarId.DefaultSetting = @"";
                colvarId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarId);

                TableSchema.TableColumn colvarGoogleId = new TableSchema.TableColumn(schema);
                colvarGoogleId.ColumnName = "GoogleId";
                colvarGoogleId.DataType = DbType.String;
                colvarGoogleId.MaxLength = 0;
                colvarGoogleId.AutoIncrement = false;
                colvarGoogleId.IsNullable = true;
                colvarGoogleId.IsPrimaryKey = false;
                colvarGoogleId.IsForeignKey = false;
                colvarGoogleId.IsReadOnly = false;
                colvarGoogleId.DefaultSetting = @"";
                colvarGoogleId.ForeignKeyTableName = "";
                schema.Columns.Add(colvarGoogleId);

                TableSchema.TableColumn colvarAvatar = new TableSchema.TableColumn(schema);
                colvarAvatar.ColumnName = "Avatar";
                colvarAvatar.DataType = DbType.String;
                colvarAvatar.MaxLength = -1;
                colvarAvatar.AutoIncrement = false;
                colvarAvatar.IsNullable = true;
                colvarAvatar.IsPrimaryKey = false;
                colvarAvatar.IsForeignKey = false;
                colvarAvatar.IsReadOnly = false;
                colvarAvatar.DefaultSetting = @"";
                colvarAvatar.ForeignKeyTableName = "";
                schema.Columns.Add(colvarAvatar);

                TableSchema.TableColumn colvarEmail = new TableSchema.TableColumn(schema);
                colvarEmail.ColumnName = "Email";
                colvarEmail.DataType = DbType.String;
                colvarEmail.MaxLength = 200;
                colvarEmail.AutoIncrement = false;
                colvarEmail.IsNullable = true;
                colvarEmail.IsPrimaryKey = false;
                colvarEmail.IsForeignKey = false;
                colvarEmail.IsReadOnly = false;
                colvarEmail.DefaultSetting = @"";
                colvarEmail.ForeignKeyTableName = "";
                schema.Columns.Add(colvarEmail);

                TableSchema.TableColumn colvarDisplayName = new TableSchema.TableColumn(schema);
                colvarDisplayName.ColumnName = "DisplayName";
                colvarDisplayName.DataType = DbType.String;
                colvarDisplayName.MaxLength = 100;
                colvarDisplayName.AutoIncrement = false;
                colvarDisplayName.IsNullable = true;
                colvarDisplayName.IsPrimaryKey = false;
                colvarDisplayName.IsForeignKey = false;
                colvarDisplayName.IsReadOnly = false;
                colvarDisplayName.DefaultSetting = @"";
                colvarDisplayName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarDisplayName);

                TableSchema.TableColumn colvarUserName = new TableSchema.TableColumn(schema);
                colvarUserName.ColumnName = "UserName";
                colvarUserName.DataType = DbType.String;
                colvarUserName.MaxLength = 100;
                colvarUserName.AutoIncrement = false;
                colvarUserName.IsNullable = true;
                colvarUserName.IsPrimaryKey = false;
                colvarUserName.IsForeignKey = false;
                colvarUserName.IsReadOnly = false;
                colvarUserName.DefaultSetting = @"";
                colvarUserName.ForeignKeyTableName = "";
                schema.Columns.Add(colvarUserName);

                TableSchema.TableColumn colvarPassword = new TableSchema.TableColumn(schema);
                colvarPassword.ColumnName = "Password";
                colvarPassword.DataType = DbType.String;
                colvarPassword.MaxLength = 100;
                colvarPassword.AutoIncrement = false;
                colvarPassword.IsNullable = true;
                colvarPassword.IsPrimaryKey = false;
                colvarPassword.IsForeignKey = false;
                colvarPassword.IsReadOnly = false;
                colvarPassword.DefaultSetting = @"";
                colvarPassword.ForeignKeyTableName = "";
                schema.Columns.Add(colvarPassword);

                TableSchema.TableColumn colvarAtCreate = new TableSchema.TableColumn(schema);
                colvarAtCreate.ColumnName = "AtCreate";
                colvarAtCreate.DataType = DbType.DateTime;
                colvarAtCreate.MaxLength = 0;
                colvarAtCreate.AutoIncrement = false;
                colvarAtCreate.IsNullable = true;
                colvarAtCreate.IsPrimaryKey = false;
                colvarAtCreate.IsForeignKey = false;
                colvarAtCreate.IsReadOnly = false;

                colvarAtCreate.DefaultSetting = @"(getdate())";
                colvarAtCreate.ForeignKeyTableName = "";
                schema.Columns.Add(colvarAtCreate);

                TableSchema.TableColumn colvarUserType = new TableSchema.TableColumn(schema);
                colvarUserType.ColumnName = "UserType";
                colvarUserType.DataType = DbType.Int32;
                colvarUserType.MaxLength = 0;
                colvarUserType.AutoIncrement = false;
                colvarUserType.IsNullable = true;
                colvarUserType.IsPrimaryKey = false;
                colvarUserType.IsForeignKey = false;
                colvarUserType.IsReadOnly = false;

                colvarUserType.DefaultSetting = @"((1))";
                colvarUserType.ForeignKeyTableName = "";
                schema.Columns.Add(colvarUserType);

                TableSchema.TableColumn colvarStatus = new TableSchema.TableColumn(schema);
                colvarStatus.ColumnName = "Status";
                colvarStatus.DataType = DbType.Int32;
                colvarStatus.MaxLength = 0;
                colvarStatus.AutoIncrement = false;
                colvarStatus.IsNullable = true;
                colvarStatus.IsPrimaryKey = false;
                colvarStatus.IsForeignKey = false;
                colvarStatus.IsReadOnly = false;

                colvarStatus.DefaultSetting = @"((1))";
                colvarStatus.ForeignKeyTableName = "";
                schema.Columns.Add(colvarStatus);

                BaseSchema = schema;
                //add this schema to the provider
                //so we can query it later
                DataService.Providers["MyDAL"].AddSchema("Users", schema);
            }
        }
        #endregion

        #region Props

        [XmlAttribute("Id")]
        [Bindable(true)]
        public int Id
        {
            get { return GetColumnValue<int>(Columns.Id); }
            set { SetColumnValue(Columns.Id, value); }
        }

        [XmlAttribute("GoogleId")]
        [Bindable(true)]
        public string GoogleId
        {
            get { return GetColumnValue<string>(Columns.GoogleId); }
            set { SetColumnValue(Columns.GoogleId, value); }
        }

        [XmlAttribute("Avatar")]
        [Bindable(true)]
        public string Avatar
        {
            get { return GetColumnValue<string>(Columns.Avatar); }
            set { SetColumnValue(Columns.Avatar, value); }
        }

        [XmlAttribute("Email")]
        [Bindable(true)]
        public string Email
        {
            get { return GetColumnValue<string>(Columns.Email); }
            set { SetColumnValue(Columns.Email, value); }
        }

        [XmlAttribute("DisplayName")]
        [Bindable(true)]
        public string DisplayName
        {
            get { return GetColumnValue<string>(Columns.DisplayName); }
            set { SetColumnValue(Columns.DisplayName, value); }
        }

        [XmlAttribute("UserName")]
        [Bindable(true)]
        public string UserName
        {
            get { return GetColumnValue<string>(Columns.UserName); }
            set { SetColumnValue(Columns.UserName, value); }
        }

        [XmlAttribute("Password")]
        [Bindable(true)]
        public string Password
        {
            get { return GetColumnValue<string>(Columns.Password); }
            set { SetColumnValue(Columns.Password, value); }
        }

        [XmlAttribute("AtCreate")]
        [Bindable(true)]
        public DateTime? AtCreate
        {
            get { return GetColumnValue<DateTime?>(Columns.AtCreate); }
            set { SetColumnValue(Columns.AtCreate, value); }
        }

        [XmlAttribute("UserType")]
        [Bindable(true)]
        public int? UserType
        {
            get { return GetColumnValue<int?>(Columns.UserType); }
            set { SetColumnValue(Columns.UserType, value); }
        }

        [XmlAttribute("Status")]
        [Bindable(true)]
        public int? Status
        {
            get { return GetColumnValue<int?>(Columns.Status); }
            set { SetColumnValue(Columns.Status, value); }
        }

        #endregion


        #region PrimaryKey Methods		

        protected override void SetPrimaryKey(object oValue)
        {
            base.SetPrimaryKey(oValue);

            SetPKValues();
        }


        public DAL.LikeCollection Likes()
        {
            return new DAL.LikeCollection().Where(Like.Columns.UserId, Id).Load();
        }
        public DAL.MessageCollection Messages()
        {
            return new DAL.MessageCollection().Where(Message.Columns.UserId, Id).Load();
        }
        #endregion



        //no foreign key tables defined (0)



        //no ManyToMany tables defined (0)



        #region ObjectDataSource support


        /// <summary>
        /// Inserts a record, can be used with the Object Data Source
        /// </summary>
        public static void Insert(string varGoogleId, string varAvatar, string varEmail, string varDisplayName, string varUserName, string varPassword, DateTime? varAtCreate, int? varUserType, int? varStatus)
        {
            User item = new User();

            item.GoogleId = varGoogleId;

            item.Avatar = varAvatar;

            item.Email = varEmail;

            item.DisplayName = varDisplayName;

            item.UserName = varUserName;

            item.Password = varPassword;

            item.AtCreate = varAtCreate;

            item.UserType = varUserType;

            item.Status = varStatus;


            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }

        /// <summary>
        /// Updates a record, can be used with the Object Data Source
        /// </summary>
        public static void Update(int varId, string varGoogleId, string varAvatar, string varEmail, string varDisplayName, string varUserName, string varPassword, DateTime? varAtCreate, int? varUserType, int? varStatus)
        {
            User item = new User();

            item.Id = varId;

            item.GoogleId = varGoogleId;

            item.Avatar = varAvatar;

            item.Email = varEmail;

            item.DisplayName = varDisplayName;

            item.UserName = varUserName;

            item.Password = varPassword;

            item.AtCreate = varAtCreate;

            item.UserType = varUserType;

            item.Status = varStatus;

            item.IsNew = false;
            if (System.Web.HttpContext.Current != null)
                item.Save(System.Web.HttpContext.Current.User.Identity.Name);
            else
                item.Save(System.Threading.Thread.CurrentPrincipal.Identity.Name);
        }
        #endregion



        #region Typed Columns


        public static TableSchema.TableColumn IdColumn
        {
            get { return Schema.Columns[0]; }
        }



        public static TableSchema.TableColumn GoogleIdColumn
        {
            get { return Schema.Columns[1]; }
        }



        public static TableSchema.TableColumn AvatarColumn
        {
            get { return Schema.Columns[2]; }
        }



        public static TableSchema.TableColumn EmailColumn
        {
            get { return Schema.Columns[3]; }
        }



        public static TableSchema.TableColumn DisplayNameColumn
        {
            get { return Schema.Columns[4]; }
        }



        public static TableSchema.TableColumn UserNameColumn
        {
            get { return Schema.Columns[5]; }
        }



        public static TableSchema.TableColumn PasswordColumn
        {
            get { return Schema.Columns[6]; }
        }



        public static TableSchema.TableColumn AtCreateColumn
        {
            get { return Schema.Columns[7]; }
        }



        public static TableSchema.TableColumn UserTypeColumn
        {
            get { return Schema.Columns[8]; }
        }



        public static TableSchema.TableColumn StatusColumn
        {
            get { return Schema.Columns[9]; }
        }



        #endregion
        #region Columns Struct
        public struct Columns
        {
            public static string Id = @"Id";
            public static string GoogleId = @"GoogleId";
            public static string Avatar = @"Avatar";
            public static string Email = @"Email";
            public static string DisplayName = @"DisplayName";
            public static string UserName = @"UserName";
            public static string Password = @"Password";
            public static string AtCreate = @"AtCreate";
            public static string UserType = @"UserType";
            public static string Status = @"Status";

        }
        #endregion

        #region Update PK Collections

        public void SetPKValues()
        {
        }
        #endregion

        #region Deep Save

        public void DeepSave()
        {
            Save();

        }
        #endregion
    }
}
