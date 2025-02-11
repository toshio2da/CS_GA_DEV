using GALib.Core.GAModel.Json;
using GALib.Core.Plugins;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GALib.Core.GAModel
{
	public class GAModelBuilder
	{
		private DefaultGAModel gaModel = null!;

		public static GAModelBuilder GetBuilder(IIndividualFactory individualFactory, IFitness fitnessAlgorithm)
		{
			return new GAModelBuilder(individualFactory, fitnessAlgorithm);
		}

		private GAModelBuilder(IIndividualFactory individualFactory, IFitness fitnessAlgorithm)
		{
			this.gaModel = new DefaultGAModel(individualFactory, fitnessAlgorithm);
		}

		public DefaultGAModel DefaultGAModel => this.gaModel;

		public IGAModel Build()
		{
			return this.gaModel;
		}

		#region プラグイン
		public GAModelBuilder SetIndividualFactory(IIndividualFactory individualFactory)
		{
			gaModel.IndividualFactory = individualFactory;
			return this;
		}

		public GAModelBuilder SetIndividualFactory(GAModelInfo gAModelInfo)
		{
			gaModel.IndividualFactory = GetGAModelInstance<IIndividualFactory>(gAModelInfo);
			return this;
		}

		public GAModelBuilder SetFitnessAlgorithm(IFitness FitnessAlgorithm)
		{
			gaModel.FitnessAlgorithm = FitnessAlgorithm;
			return this;
		}

		public GAModelBuilder SetFitnessAlgorithm(GAModelInfo gAModelInfo)
		{
			gaModel.FitnessAlgorithm = GetGAModelInstance<IFitness>(gAModelInfo);
			return this;
		}

		public GAModelBuilder SetSelectionAlgorithm(ISelection selectionAlgorithm)
		{
			gaModel.SelectionAlgorithm = selectionAlgorithm;
			return this;
		}

		public GAModelBuilder SetSelectionAlgorithm(GAModelInfo gAModelInfo)
		{
			gaModel.SelectionAlgorithm = GetGAModelInstance<ISelection>(gAModelInfo);
			return this;
		}

		public GAModelBuilder SetSurviveAlgorithm(ISurvive surviveAlgorithm)
		{
			gaModel.SurviveAlgorithm = surviveAlgorithm;
			return this;
		}

		public GAModelBuilder SetSurviveAlgorithm(GAModelInfo gAModelInfo)
		{
			gaModel.SurviveAlgorithm = GetGAModelInstance<ISurvive>(gAModelInfo);
			return this;
		}
		public GAModelBuilder SetCrossoverAlgorithm(ICrossover crossoverAlgorithm)
		{
			gaModel.CrossoverAlgorithm = crossoverAlgorithm;
			return this;
		}

		public GAModelBuilder SetCrossoverAlgorithm(GAModelInfo gAModelInfo)
		{
			gaModel.CrossoverAlgorithm = GetGAModelInstance<ICrossover>(gAModelInfo);
			return this;
		}

		public GAModelBuilder SetMutationAlgorithm(IMutation mutationAlgorithm)
		{
			gaModel.MutationAlgorithm = mutationAlgorithm;
			return this;
		}

		public GAModelBuilder SetMutationAlgorithm(GAModelInfo gAModelInfo)
		{
			gaModel.MutationAlgorithm = GetGAModelInstance<IMutation>(gAModelInfo);
			return this;
		}

		public GAModelBuilder SetInverseAlgorithm(IInverse inverseAlgorithm)
		{
			gaModel.InverseAlgorithm = inverseAlgorithm;
			return this;
		}

		public GAModelBuilder SetInverseAlgorithm(GAModelInfo gAModelInfo)
		{
			gaModel.InverseAlgorithm = GetGAModelInstance<IInverse>(gAModelInfo);
			return this;
		}
		#endregion


		public static T GetGAModelInstance<T>(GAModelInfo gAModelInfo)
		{
			string classTypeName = $"{gAModelInfo.ClassName},{gAModelInfo.AssemblyName}";
			Type? classType = Type.GetType(classTypeName);
			if (classType == null) throw new ArgumentException($"{classTypeName}のGAModeプラグインが見つかりません");

			if (!classType.GetInterfaces().Any(x => x.IsConstructedGenericType && x.GetGenericTypeDefinition() == typeof(T)))
			{
				throw new ArgumentException($"{classTypeName}のGAModeプラグインが指定されたインタフェースを実装していません");
			}

			ConstructorInfo? constructorInfo = null;
			if (gAModelInfo.InitParams != null && gAModelInfo.InitParams.Count > 0)
			{
				Type[] types = gAModelInfo.InitParams.Select(x => x.ParamType).ToArray();
				constructorInfo = classType.GetConstructor(types);
			}
			else
			{
				constructorInfo = classType.GetConstructor(Type.EmptyTypes);
			}
			if (classType == null) throw new ArgumentException($"{classTypeName}のGAModeプラグインのコンストラクタが見つかりません");

			object? instance = null;
			if (gAModelInfo.InitParams != null && gAModelInfo.InitParams.Count > 0)
			{
				object?[]? values = gAModelInfo.InitParams.Select(x => Convert.ChangeType(x.ParamValue, x.ParamType)).ToArray();
				instance = constructorInfo?.Invoke(values);
			}
			else
			{
				instance = constructorInfo?.Invoke(null);
			}

			if (instance == null) throw new ArgumentException($"{classTypeName}のGAModeプラグインがインスタンス化できません");

			return (T)instance;
		}
	}
}
