﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("DataStore", "FK_Campaign_Vendor", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(DataStore.Vendor), "Campaign", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(DataStore.Campaign), true)]
[assembly: EdmRelationshipAttribute("DataStore", "FK_CampaignProperties_Campaign", "Campaign", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(DataStore.Campaign), "CampaignProperties", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(DataStore.CampaignProperty), true)]
[assembly: EdmRelationshipAttribute("DataStore", "FK_VendorProperties_Vendor", "Vendor", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(DataStore.Vendor), "VendorProperties", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(DataStore.VendorProperty), true)]

#endregion

namespace DataStore
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class NewsletterEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new NewsletterEntities object using the connection string found in the 'NewsletterEntities' section of the application configuration file.
        /// </summary>
        public NewsletterEntities() : base("name=NewsletterEntities", "NewsletterEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new NewsletterEntities object.
        /// </summary>
        public NewsletterEntities(string connectionString) : base(connectionString, "NewsletterEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new NewsletterEntities object.
        /// </summary>
        public NewsletterEntities(EntityConnection connection) : base(connection, "NewsletterEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Campaign> Campaigns
        {
            get
            {
                if ((_Campaigns == null))
                {
                    _Campaigns = base.CreateObjectSet<Campaign>("Campaigns");
                }
                return _Campaigns;
            }
        }
        private ObjectSet<Campaign> _Campaigns;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<CampaignProperty> CampaignProperties
        {
            get
            {
                if ((_CampaignProperties == null))
                {
                    _CampaignProperties = base.CreateObjectSet<CampaignProperty>("CampaignProperties");
                }
                return _CampaignProperties;
            }
        }
        private ObjectSet<CampaignProperty> _CampaignProperties;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Vendor> Vendors
        {
            get
            {
                if ((_Vendors == null))
                {
                    _Vendors = base.CreateObjectSet<Vendor>("Vendors");
                }
                return _Vendors;
            }
        }
        private ObjectSet<Vendor> _Vendors;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<VendorProperty> VendorProperties
        {
            get
            {
                if ((_VendorProperties == null))
                {
                    _VendorProperties = base.CreateObjectSet<VendorProperty>("VendorProperties");
                }
                return _VendorProperties;
            }
        }
        private ObjectSet<VendorProperty> _VendorProperties;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Campaigns EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCampaigns(Campaign campaign)
        {
            base.AddObject("Campaigns", campaign);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the CampaignProperties EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCampaignProperties(CampaignProperty campaignProperty)
        {
            base.AddObject("CampaignProperties", campaignProperty);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Vendors EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToVendors(Vendor vendor)
        {
            base.AddObject("Vendors", vendor);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the VendorProperties EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToVendorProperties(VendorProperty vendorProperty)
        {
            base.AddObject("VendorProperties", vendorProperty);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DataStore", Name="Campaign")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Campaign : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Campaign object.
        /// </summary>
        /// <param name="campaignID">Initial value of the CampaignID property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="vendorID">Initial value of the VendorID property.</param>
        /// <param name="dateCreated">Initial value of the DateCreated property.</param>
        /// <param name="dateModified">Initial value of the DateModified property.</param>
        /// <param name="isActive">Initial value of the isActive property.</param>
        public static Campaign CreateCampaign(global::System.Int16 campaignID, global::System.String name, global::System.Int16 vendorID, global::System.DateTime dateCreated, global::System.DateTime dateModified, global::System.Boolean isActive)
        {
            Campaign campaign = new Campaign();
            campaign.CampaignID = campaignID;
            campaign.Name = name;
            campaign.VendorID = vendorID;
            campaign.DateCreated = dateCreated;
            campaign.DateModified = dateModified;
            campaign.isActive = isActive;
            return campaign;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 CampaignID
        {
            get
            {
                return _CampaignID;
            }
            set
            {
                if (_CampaignID != value)
                {
                    OnCampaignIDChanging(value);
                    ReportPropertyChanging("CampaignID");
                    _CampaignID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("CampaignID");
                    OnCampaignIDChanged();
                }
            }
        }
        private global::System.Int16 _CampaignID;
        partial void OnCampaignIDChanging(global::System.Int16 value);
        partial void OnCampaignIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 VendorID
        {
            get
            {
                return _VendorID;
            }
            set
            {
                OnVendorIDChanging(value);
                ReportPropertyChanging("VendorID");
                _VendorID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VendorID");
                OnVendorIDChanged();
            }
        }
        private global::System.Int16 _VendorID;
        partial void OnVendorIDChanging(global::System.Int16 value);
        partial void OnVendorIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }
            set
            {
                OnDateCreatedChanging(value);
                ReportPropertyChanging("DateCreated");
                _DateCreated = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateCreated");
                OnDateCreatedChanged();
            }
        }
        private global::System.DateTime _DateCreated;
        partial void OnDateCreatedChanging(global::System.DateTime value);
        partial void OnDateCreatedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateModified
        {
            get
            {
                return _DateModified;
            }
            set
            {
                OnDateModifiedChanging(value);
                ReportPropertyChanging("DateModified");
                _DateModified = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateModified");
                OnDateModifiedChanged();
            }
        }
        private global::System.DateTime _DateModified;
        partial void OnDateModifiedChanging(global::System.DateTime value);
        partial void OnDateModifiedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean isActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                OnisActiveChanging(value);
                ReportPropertyChanging("isActive");
                _isActive = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("isActive");
                OnisActiveChanged();
            }
        }
        private global::System.Boolean _isActive;
        partial void OnisActiveChanging(global::System.Boolean value);
        partial void OnisActiveChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("DataStore", "FK_Campaign_Vendor", "Vendor")]
        public Vendor Vendor
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Vendor>("DataStore.FK_Campaign_Vendor", "Vendor").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Vendor>("DataStore.FK_Campaign_Vendor", "Vendor").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Vendor> VendorReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Vendor>("DataStore.FK_Campaign_Vendor", "Vendor");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Vendor>("DataStore.FK_Campaign_Vendor", "Vendor", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("DataStore", "FK_CampaignProperties_Campaign", "CampaignProperties")]
        public EntityCollection<CampaignProperty> CampaignProperties
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<CampaignProperty>("DataStore.FK_CampaignProperties_Campaign", "CampaignProperties");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<CampaignProperty>("DataStore.FK_CampaignProperties_Campaign", "CampaignProperties", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DataStore", Name="CampaignProperty")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class CampaignProperty : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new CampaignProperty object.
        /// </summary>
        /// <param name="propertyID">Initial value of the PropertyID property.</param>
        /// <param name="campaignID">Initial value of the CampaignID property.</param>
        /// <param name="propertyName">Initial value of the PropertyName property.</param>
        /// <param name="propertyValue">Initial value of the PropertyValue property.</param>
        /// <param name="dateCreated">Initial value of the DateCreated property.</param>
        /// <param name="dateModified">Initial value of the DateModified property.</param>
        public static CampaignProperty CreateCampaignProperty(global::System.Int32 propertyID, global::System.Int16 campaignID, global::System.String propertyName, global::System.String propertyValue, global::System.DateTime dateCreated, global::System.DateTime dateModified)
        {
            CampaignProperty campaignProperty = new CampaignProperty();
            campaignProperty.PropertyID = propertyID;
            campaignProperty.CampaignID = campaignID;
            campaignProperty.PropertyName = propertyName;
            campaignProperty.PropertyValue = propertyValue;
            campaignProperty.DateCreated = dateCreated;
            campaignProperty.DateModified = dateModified;
            return campaignProperty;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PropertyID
        {
            get
            {
                return _PropertyID;
            }
            set
            {
                if (_PropertyID != value)
                {
                    OnPropertyIDChanging(value);
                    ReportPropertyChanging("PropertyID");
                    _PropertyID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("PropertyID");
                    OnPropertyIDChanged();
                }
            }
        }
        private global::System.Int32 _PropertyID;
        partial void OnPropertyIDChanging(global::System.Int32 value);
        partial void OnPropertyIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 CampaignID
        {
            get
            {
                return _CampaignID;
            }
            set
            {
                OnCampaignIDChanging(value);
                ReportPropertyChanging("CampaignID");
                _CampaignID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CampaignID");
                OnCampaignIDChanged();
            }
        }
        private global::System.Int16 _CampaignID;
        partial void OnCampaignIDChanging(global::System.Int16 value);
        partial void OnCampaignIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String PropertyName
        {
            get
            {
                return _PropertyName;
            }
            set
            {
                OnPropertyNameChanging(value);
                ReportPropertyChanging("PropertyName");
                _PropertyName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("PropertyName");
                OnPropertyNameChanged();
            }
        }
        private global::System.String _PropertyName;
        partial void OnPropertyNameChanging(global::System.String value);
        partial void OnPropertyNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String PropertyValue
        {
            get
            {
                return _PropertyValue;
            }
            set
            {
                OnPropertyValueChanging(value);
                ReportPropertyChanging("PropertyValue");
                _PropertyValue = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("PropertyValue");
                OnPropertyValueChanged();
            }
        }
        private global::System.String _PropertyValue;
        partial void OnPropertyValueChanging(global::System.String value);
        partial void OnPropertyValueChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }
            set
            {
                OnDateCreatedChanging(value);
                ReportPropertyChanging("DateCreated");
                _DateCreated = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateCreated");
                OnDateCreatedChanged();
            }
        }
        private global::System.DateTime _DateCreated;
        partial void OnDateCreatedChanging(global::System.DateTime value);
        partial void OnDateCreatedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateModified
        {
            get
            {
                return _DateModified;
            }
            set
            {
                OnDateModifiedChanging(value);
                ReportPropertyChanging("DateModified");
                _DateModified = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateModified");
                OnDateModifiedChanged();
            }
        }
        private global::System.DateTime _DateModified;
        partial void OnDateModifiedChanging(global::System.DateTime value);
        partial void OnDateModifiedChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("DataStore", "FK_CampaignProperties_Campaign", "Campaign")]
        public Campaign Campaign
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Campaign>("DataStore.FK_CampaignProperties_Campaign", "Campaign").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Campaign>("DataStore.FK_CampaignProperties_Campaign", "Campaign").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Campaign> CampaignReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Campaign>("DataStore.FK_CampaignProperties_Campaign", "Campaign");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Campaign>("DataStore.FK_CampaignProperties_Campaign", "Campaign", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DataStore", Name="Vendor")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Vendor : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Vendor object.
        /// </summary>
        /// <param name="vendorID">Initial value of the VendorID property.</param>
        /// <param name="vendorName">Initial value of the VendorName property.</param>
        /// <param name="dateCreated">Initial value of the DateCreated property.</param>
        /// <param name="dateModified">Initial value of the DateModified property.</param>
        public static Vendor CreateVendor(global::System.Int16 vendorID, global::System.String vendorName, global::System.DateTime dateCreated, global::System.DateTime dateModified)
        {
            Vendor vendor = new Vendor();
            vendor.VendorID = vendorID;
            vendor.VendorName = vendorName;
            vendor.DateCreated = dateCreated;
            vendor.DateModified = dateModified;
            return vendor;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 VendorID
        {
            get
            {
                return _VendorID;
            }
            set
            {
                if (_VendorID != value)
                {
                    OnVendorIDChanging(value);
                    ReportPropertyChanging("VendorID");
                    _VendorID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("VendorID");
                    OnVendorIDChanged();
                }
            }
        }
        private global::System.Int16 _VendorID;
        partial void OnVendorIDChanging(global::System.Int16 value);
        partial void OnVendorIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String VendorName
        {
            get
            {
                return _VendorName;
            }
            set
            {
                OnVendorNameChanging(value);
                ReportPropertyChanging("VendorName");
                _VendorName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("VendorName");
                OnVendorNameChanged();
            }
        }
        private global::System.String _VendorName;
        partial void OnVendorNameChanging(global::System.String value);
        partial void OnVendorNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }
            set
            {
                OnDateCreatedChanging(value);
                ReportPropertyChanging("DateCreated");
                _DateCreated = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateCreated");
                OnDateCreatedChanged();
            }
        }
        private global::System.DateTime _DateCreated;
        partial void OnDateCreatedChanging(global::System.DateTime value);
        partial void OnDateCreatedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateModified
        {
            get
            {
                return _DateModified;
            }
            set
            {
                OnDateModifiedChanging(value);
                ReportPropertyChanging("DateModified");
                _DateModified = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateModified");
                OnDateModifiedChanged();
            }
        }
        private global::System.DateTime _DateModified;
        partial void OnDateModifiedChanging(global::System.DateTime value);
        partial void OnDateModifiedChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("DataStore", "FK_Campaign_Vendor", "Campaign")]
        public EntityCollection<Campaign> Campaigns
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Campaign>("DataStore.FK_Campaign_Vendor", "Campaign");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Campaign>("DataStore.FK_Campaign_Vendor", "Campaign", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("DataStore", "FK_VendorProperties_Vendor", "VendorProperties")]
        public EntityCollection<VendorProperty> VendorProperties
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<VendorProperty>("DataStore.FK_VendorProperties_Vendor", "VendorProperties");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<VendorProperty>("DataStore.FK_VendorProperties_Vendor", "VendorProperties", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DataStore", Name="VendorProperty")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class VendorProperty : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new VendorProperty object.
        /// </summary>
        /// <param name="propertyID">Initial value of the PropertyID property.</param>
        /// <param name="vendorID">Initial value of the VendorID property.</param>
        /// <param name="propertyName">Initial value of the PropertyName property.</param>
        /// <param name="propertyValue">Initial value of the PropertyValue property.</param>
        /// <param name="dateCreated">Initial value of the DateCreated property.</param>
        /// <param name="dateModified">Initial value of the DateModified property.</param>
        public static VendorProperty CreateVendorProperty(global::System.Int16 propertyID, global::System.Int16 vendorID, global::System.String propertyName, global::System.String propertyValue, global::System.DateTime dateCreated, global::System.DateTime dateModified)
        {
            VendorProperty vendorProperty = new VendorProperty();
            vendorProperty.PropertyID = propertyID;
            vendorProperty.VendorID = vendorID;
            vendorProperty.PropertyName = propertyName;
            vendorProperty.PropertyValue = propertyValue;
            vendorProperty.DateCreated = dateCreated;
            vendorProperty.DateModified = dateModified;
            return vendorProperty;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 PropertyID
        {
            get
            {
                return _PropertyID;
            }
            set
            {
                if (_PropertyID != value)
                {
                    OnPropertyIDChanging(value);
                    ReportPropertyChanging("PropertyID");
                    _PropertyID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("PropertyID");
                    OnPropertyIDChanged();
                }
            }
        }
        private global::System.Int16 _PropertyID;
        partial void OnPropertyIDChanging(global::System.Int16 value);
        partial void OnPropertyIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 VendorID
        {
            get
            {
                return _VendorID;
            }
            set
            {
                OnVendorIDChanging(value);
                ReportPropertyChanging("VendorID");
                _VendorID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VendorID");
                OnVendorIDChanged();
            }
        }
        private global::System.Int16 _VendorID;
        partial void OnVendorIDChanging(global::System.Int16 value);
        partial void OnVendorIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String PropertyName
        {
            get
            {
                return _PropertyName;
            }
            set
            {
                OnPropertyNameChanging(value);
                ReportPropertyChanging("PropertyName");
                _PropertyName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("PropertyName");
                OnPropertyNameChanged();
            }
        }
        private global::System.String _PropertyName;
        partial void OnPropertyNameChanging(global::System.String value);
        partial void OnPropertyNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String PropertyValue
        {
            get
            {
                return _PropertyValue;
            }
            set
            {
                OnPropertyValueChanging(value);
                ReportPropertyChanging("PropertyValue");
                _PropertyValue = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("PropertyValue");
                OnPropertyValueChanged();
            }
        }
        private global::System.String _PropertyValue;
        partial void OnPropertyValueChanging(global::System.String value);
        partial void OnPropertyValueChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateCreated
        {
            get
            {
                return _DateCreated;
            }
            set
            {
                OnDateCreatedChanging(value);
                ReportPropertyChanging("DateCreated");
                _DateCreated = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateCreated");
                OnDateCreatedChanged();
            }
        }
        private global::System.DateTime _DateCreated;
        partial void OnDateCreatedChanging(global::System.DateTime value);
        partial void OnDateCreatedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateModified
        {
            get
            {
                return _DateModified;
            }
            set
            {
                OnDateModifiedChanging(value);
                ReportPropertyChanging("DateModified");
                _DateModified = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateModified");
                OnDateModifiedChanged();
            }
        }
        private global::System.DateTime _DateModified;
        partial void OnDateModifiedChanging(global::System.DateTime value);
        partial void OnDateModifiedChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("DataStore", "FK_VendorProperties_Vendor", "Vendor")]
        public Vendor Vendor
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Vendor>("DataStore.FK_VendorProperties_Vendor", "Vendor").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Vendor>("DataStore.FK_VendorProperties_Vendor", "Vendor").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Vendor> VendorReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Vendor>("DataStore.FK_VendorProperties_Vendor", "Vendor");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Vendor>("DataStore.FK_VendorProperties_Vendor", "Vendor", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}