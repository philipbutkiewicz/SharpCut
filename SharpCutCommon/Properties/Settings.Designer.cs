﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SharpCutCommon.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.7.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public float TimelineScrollSpeed {
            get {
                return ((float)(this["TimelineScrollSpeed"]));
            }
            set {
                this["TimelineScrollSpeed"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool AutoSaveProject {
            get {
                return ((bool)(this["AutoSaveProject"]));
            }
            set {
                this["AutoSaveProject"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DarkMode {
            get {
                return ((bool)(this["DarkMode"]));
            }
            set {
                this["DarkMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool GenerateFastPreview {
            get {
                return ((bool)(this["GenerateFastPreview"]));
            }
            set {
                this["GenerateFastPreview"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("24/60")]
        public string PreviewRate {
            get {
                return ((string)(this["PreviewRate"]));
            }
            set {
                this["PreviewRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1800")]
        public int TimeUntilCourtesy {
            get {
                return ((int)(this["TimeUntilCourtesy"]));
            }
            set {
                this["TimeUntilCourtesy"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool CourtesyEnabled {
            get {
                return ((bool)(this["CourtesyEnabled"]));
            }
            set {
                this["CourtesyEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("$(OriginalFn)-proj.$(Ext)")]
        public string ProjectFileNameTemplate {
            get {
                return ((string)(this["ProjectFileNameTemplate"]));
            }
            set {
                this["ProjectFileNameTemplate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("$(OriginalFn)_$(SegStart)-$(SegEnd).$(Ext)")]
        public string SegmentFileNameTemplate {
            get {
                return ((string)(this["SegmentFileNameTemplate"]));
            }
            set {
                this["SegmentFileNameTemplate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("$(OriginalFn)_merged.$(Ext)")]
        public string MergedFileNameTemplate {
            get {
                return ((string)(this["MergedFileNameTemplate"]));
            }
            set {
                this["MergedFileNameTemplate"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool IsBetaBuild {
            get {
                return ((bool)(this["IsBetaBuild"]));
            }
        }
    }
}
