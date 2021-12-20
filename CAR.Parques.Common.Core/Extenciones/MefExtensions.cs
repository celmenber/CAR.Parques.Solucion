﻿namespace CAR.Parques.Common.Core.Extenciones
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.ComponentModel.Composition.Primitives;
    using System.Linq;

    public static class MefExtensions
    {
        public static object GetExportedValueByType(this CompositionContainer container, Type type)
        {
            foreach (var partDef in container.Catalog.Parts)
            {
                foreach (var exportDef in partDef.ExportDefinitions)
                {
                    if (exportDef.ContractName == type.FullName)
                    {
                        var contracto = AttributedModelServices.GetContractName(type);
                        var definicion = new ContractBasedImportDefinition(
                            contracto,
                            contracto,
                            null,
                            ImportCardinality.ExactlyOne,
                            false,
                            false,
                            CreationPolicy.Any);
                        return container.GetExports(definicion).FirstOrDefault().Value;
                    }
                }
            }
            return null;
        }

        public static IEnumerable<object> GetExportedValuesByType(this CompositionContainer container, Type type)
        {
            foreach (var partDef in container.Catalog.Parts)
            {
                foreach (var exportDef in partDef.ExportDefinitions)
                {
                    if (exportDef.ContractName == type.FullName)
                    {
                        var contracto = AttributedModelServices.GetContractName(type);
                        var definicion = new ContractBasedImportDefinition(
                            contracto,
                            contracto,
                            null,
                            ImportCardinality.ExactlyOne,
                            false,
                            false,
                            CreationPolicy.Any);
                        return container.GetExports(definicion);
                    }
                }
            }
            return new List<object>();
        }

        public static T GetExportedValue<T>(
            this CompositionContainer container,
            Func<IDictionary<string, object>, bool> predicate)
        {
            foreach (var partDef in container.Catalog.Parts)
            {
                foreach (var exportDef in partDef.ExportDefinitions)
                {
                    if (exportDef.ContractName == typeof(T).FullName)
                    {
                        if (predicate(exportDef.Metadata))
                        {
                            return (T)partDef.CreatePart().GetExportedValue(exportDef);
                        }
                    }
                }
            }
            return default(T);
        }

        public static T GetExportedValueByType<T>(this CompositionContainer container, string type)
        {
            foreach (var partDef in container.Catalog.Parts)
            {
                foreach (var exportDef in partDef.ExportDefinitions)
                {
                    if (exportDef.ContractName == type)
                    {
                        return (T)partDef.CreatePart().GetExportedValue(exportDef);
                    }
                }
            }
            return default(T);
        }
    }
}
