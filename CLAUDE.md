# CLAUDE.md - CS_GA_DEV Repository Guide

## Project Overview

**CS_GA_DEV** is a professional C# genetic algorithm library with a Windows Forms demonstration application. The repository contains a production-ready framework for solving combinatorial optimization problems using genetic algorithms.

- **Framework**: .NET 8.0 (LTS)
- **Language**: C# with nullable reference types enabled
- **Architecture**: Strategy pattern with dependency injection
- **Size**: ~4,400 lines of code across 56 C# files
- **Primary Language**: Code comments are in Japanese (日本語)

---

## Repository Structure

```
CS_GA_DEV/
├── CS_GA_DEV.sln                    # Visual Studio solution file
├── .gitignore                        # Git ignore rules (excludes .vs, bin, obj)
├── GeneticAlgorithm/                 # Core library project
│   ├── GeneticAlgorithm.csproj      # Class library project file
│   ├── GeneticAlgorithm/            # Main algorithm components (PascalCase)
│   │   ├── IGAModel.cs              # Core model interface
│   │   ├── IGeneticAlgorithm.cs     # Main algorithm interface
│   │   ├── GASearchMethod.cs        # Search method enumeration
│   │   ├── GASearchStatus.cs        # Search status tracking
│   │   ├── Crossovers/              # Crossover algorithms
│   │   │   ├── ICrossoverAlgorithm.cs
│   │   │   ├── OnePointCrossover.cs
│   │   │   └── TwoPointCrossover.cs
│   │   ├── Selections/              # Selection algorithms
│   │   │   ├── ISelectionAlgorithm.cs
│   │   │   └── TournamentMethod.cs
│   │   ├── Survivals/               # Survival strategies
│   │   │   ├── ISurvivalAlgorithm.cs
│   │   │   └── EliteStrategy.cs
│   │   ├── Fitnesses/               # Fitness calculation
│   │   │   └── IFitnessAlgorithm.cs
│   │   ├── Genes/                   # Gene implementations
│   │   │   ├── IGene.cs
│   │   │   ├── BinaryGene.cs
│   │   │   ├── NumberGene.cs
│   │   │   └── LimitedNumberGene.cs
│   │   ├── Individuals/             # Individual models
│   │   │   ├── Individual.cs
│   │   │   ├── IIndividualModel.cs
│   │   │   ├── BinaryIndividualModel.cs
│   │   │   ├── NumberIndividualModel.cs
│   │   │   └── LimitedNumberIndividualModel.cs
│   │   └── Exceptions/              # Custom exceptions (11 types)
│   │       ├── GeneticAlgorithmException.cs
│   │       ├── IllegalElementException.cs
│   │       ├── IllegalParameterTypeException.cs
│   │       └── ... (8 more)
│   ├── geneticalgorithm/            # Legacy components (camelCase)
│   │   ├── GeneticAlgorithm.cs      # Main algorithm implementation
│   │   ├── IGeneticReportable.cs    # Observer interface
│   │   ├── DefaultGeneticReporter.cs
│   │   └── sample/                  # Sample N-Queen implementation
│   └── Utils/                       # Utility classes
│       ├── RandomGenerator.cs
│       └── DataTools.cs
└── NQueenGASample/                  # Windows Forms demo application
    ├── NQueenGASample.csproj        # WinForms project file
    ├── Program.cs                   # Application entry point
    ├── TestForm.cs                  # Main form
    ├── TestForm.Designer.cs         # Form designer code
    ├── BoardCtrl.cs                 # Chess board control
    ├── NQueenGAModel.cs             # N-Queen GA model
    ├── NQueenFitnessAlgorithm.cs    # Fitness calculation
    ├── NQueenGAObserver.cs          # Progress observer
    └── NQueenToHtmlConverter.cs     # HTML visualization converter
```

---

## Project Configuration

### GeneticAlgorithm (Core Library)

**File**: `GeneticAlgorithm/GeneticAlgorithm.csproj`

```xml
<TargetFramework>net8.0</TargetFramework>
<ImplicitUsings>enable</ImplicitUsings>
<Nullable>enable</Nullable>
<RootNamespace>jp.co.tmdgroup.common</RootNamespace>
```

- **Output**: Class library (DLL)
- **Dependencies**: None (zero external dependencies)
- **Configurations**: Debug, Release

### NQueenGASample (Demo Application)

**File**: `NQueenGASample/NQueenGASample.csproj`

```xml
<OutputType>WinExe</OutputType>
<TargetFramework>net8.0-windows</TargetFramework>
<UseWindowsForms>true</UseWindowsForms>
<RootNamespace>jp.co.tmdgroup.nqueengasample</RootNamespace>
```

- **Output**: Windows executable
- **Dependencies**:
  - GeneticAlgorithm project reference
  - Microsoft.Web.WebView2 (v1.0.2903.40)

---

## Namespace Conventions

### Core Library
- **Root**: `jp.co.tmdgroup.common`
- **Algorithm**: `jp.co.tmdgroup.common.GeneticAlgorithm`
- **Components**: `jp.co.tmdgroup.common.GeneticAlgorithm.{Crossovers|Selections|Survivals|Fitnesses|Genes|Individuals|Exceptions}`
- **Utilities**: `jp.co.tmdgroup.common.Utils`

### Sample Application
- **Root**: `jp.co.tmdgroup.nqueengasample`

---

## Architecture & Design Patterns

### Strategy Pattern (Core Design)

The library uses the **Strategy Pattern** extensively for algorithm flexibility:

1. **IGAModel Interface**: Central configuration point that aggregates all algorithm strategies
2. **Pluggable Algorithms**: Each GA component is swappable via interfaces:
   - `IFitnessAlgorithm` - Fitness calculation
   - `ISelectionAlgorithm` - Parent selection (Tournament, Roulette, etc.)
   - `ISurvivalAlgorithm` - Survival strategy (Elite, etc.)
   - `ICrossoverAlgorithm` - Genetic crossover (One-point, Two-point)
   - `IIndividualModel` - Gene type and structure

### Dependency Injection

Models are injected into the `GeneticAlgorithm` class via constructor:

```csharp
public GeneticAlgorithm(IGAModel model)
{
    this.model = model;
}
```

### Observer Pattern

Progress reporting uses the observer pattern:
- `IGeneticReportable` interface for status updates
- `DefaultGeneticReporter` as default implementation
- `GASearchContext` for thread-safe context management

### Key Interfaces

#### IGAModel (Core Configuration)
```csharp
public interface IGAModel
{
    IIndividualModel IndividualModel { get; }
    IFitnessAlgorithm FitnessAlgorithm { get; }
    ISelectionAlgorithm SelectionAlgorithm { get; }
    ISurvivalAlgorithm SurvivalAlgorithm { get; }
    ICrossoverAlgorithm CrossoverAlgorithm { get; }
    double MutationProbability { get; }
    double InverseProbability { get; }
}
```

#### Implementation Pattern

All models extend `AbstractGAModel` and configure their strategies:

```csharp
public class NQueenGAModel : AbstractGAModel
{
    public NQueenGAModel(int N)
    {
        this.IndividualModel = new LimitedNumberIndividualModel(N, N);
        this.FitnessAlgorithm = new NQueenFitnessAlgorithm();
        this.SelectionAlgorithm = new TournamentMethod(2);
        this.SurvivalAlgorithm = new EliteStrategy(0.95);
        this.CrossoverAlgorithm = new OnePointCrossover();
    }
}
```

---

## Code Conventions

### Naming Conventions

1. **Classes**: PascalCase (e.g., `GeneticAlgorithm`, `Individual`)
2. **Interfaces**: Prefix with 'I' (e.g., `IGAModel`, `IFitnessAlgorithm`)
3. **Methods**: PascalCase (e.g., `CalculateFitness()`)
4. **Properties**: PascalCase (e.g., `MutationProbability`)
5. **Private Fields**: camelCase with `this.` prefix (e.g., `this.model`)
6. **Constants**: UPPER_CASE or PascalCase

### Comment Style

**Important**: Comments are predominantly in **Japanese** (日本語)

- **Class Documentation**: Javadoc-style with `/**` blocks
- **Copyright**: Includes original author (森本寛) and company (株式会社東京マイクロデータ)
- **Inline Comments**: Use `//------` decorative separators

Example:
```csharp
/**
 /// <p>遺伝的アルゴリズムにより様々な組み合わせ問題の準最適解を高速に検索します。</p>
 /// <p>タイトル: Genetic Algorithm Library</p>
 /// <p>説明: 汎用的な遺伝的アルゴリズムライブラリ</p>
 /// <p>著作権: Copyright (c) 2002  森本寛</p>
 /// <p>会社名: 株式会社東京マイクロデータ</p>
 /// @author 森本寛
 /// @version 1.0
 */
```

### Code Style

- **Nullable Reference Types**: Enabled (`<Nullable>enable</Nullable>`)
- **Implicit Usings**: Enabled
- **Field Initialization**: Modern syntax (e.g., `List<Individual> group = [];`)
- **Error Handling**: Custom exception hierarchy under `GeneticAlgorithm.Exceptions`
- **Thread Safety**: Context managed via synchronized access

---

## File Organization Peculiarities

**Important**: The repository has **mixed-case folder naming**:

- `GeneticAlgorithm/GeneticAlgorithm/` - PascalCase (newer code)
- `GeneticAlgorithm/geneticalgorithm/` - camelCase (legacy code)

When adding new files:
- **New algorithm components**: Place in `GeneticAlgorithm/GeneticAlgorithm/{Category}/`
- **Legacy compatibility**: Keep in `GeneticAlgorithm/geneticalgorithm/`
- **DO NOT** mix conventions within a single module

---

## Development Workflow

### Building the Solution

```bash
# Build entire solution
dotnet build CS_GA_DEV.sln

# Build specific project
dotnet build GeneticAlgorithm/GeneticAlgorithm.csproj
dotnet build NQueenGASample/NQueenGASample.csproj

# Release build
dotnet build CS_GA_DEV.sln -c Release
```

### Running the Sample Application

```bash
# Run from project directory
dotnet run --project NQueenGASample/NQueenGASample.csproj

# Or run the compiled executable
dotnet NQueenGASample/bin/Debug/net8.0-windows/NQueenGASample.dll
```

### Testing

**Note**: No unit test project currently exists in the solution.

When adding tests:
1. Create a new xUnit/NUnit project
2. Name it `GeneticAlgorithm.Tests`
3. Target `net8.0`
4. Add project reference to `GeneticAlgorithm`

---

## Git Conventions

### Commit Messages

**Important**: Commit messages are in **Japanese** (日本語)

Recent examples:
```
010afea ファイル名更新の為追加
6ee1b23 テストフォームを簡略化
b6cfc47 GAエンジン関連をマージ
8731a81 ・GA Searchの結果をGaSearchResultに変更
```

### Branch Strategy

- **Main Branch**: Not explicitly set (check with maintainer)
- **Feature Branches**: Use `claude/` prefix for AI-assisted development
- **Current Branch**: `claude/claude-md-mi2ms5duemvh1bzx-018Se9inMoLqUhfs1MZ1GsJo`

### .gitignore

Excludes:
- `.vs/` - Visual Studio settings
- `bin/` - Build output
- `obj/` - Intermediate files

---

## Key Components Deep Dive

### Gene Types

1. **BinaryGene**: Binary representation (0/1)
2. **NumberGene**: Integer array
3. **LimitedNumberGene**: Unique integers within range (used for N-Queen)

### Selection Algorithms

- **TournamentMethod**: K individuals compete, best wins
  - Default tournament size: 2
  - Configurable via constructor

### Crossover Algorithms

- **OnePointCrossover**: Single crossover point
- **TwoPointCrossover**: Two crossover points (recommended)

### Survival Strategies

- **EliteStrategy**: Preserve top percentage of population
  - Generation gap (G): 0.95 typical
  - G=1.0: No survival (full replacement)

### Search Configuration

**GASearchMethod** enum:
- `GenerationNumber` - Fixed generations
- `TimeSearch` - Time-limited search
- `GenerationAndTime` - Both constraints
- `StopSearchInterval` - Stop if no improvement

**Configuration Properties**:
```csharp
SearchingTime           // Search duration [seconds], -1 = unlimited
StopSearchInterval      // Stop if no improvement [seconds], -1 = disabled
StopSearchGeneration    // Stop if no improvement [generations], -1 = disabled
```

---

## Exception Hierarchy

Custom exceptions under `jp.co.tmdgroup.common.GeneticAlgorithm.Exceptions`:

1. `TmdException` - Base exception
2. `GeneticAlgorithmException` - GA-specific base
3. `IllegalElementException` - Invalid element
4. `IllegalParameterTypeException` - Wrong parameter type
5. `IllegalParameterSizeException` - Wrong parameter size
6. `OutOfBoundsGeneException` - Gene value out of range
7. `IllegalGenoSizeException` - Invalid gene size
8. `IllegalIndividualException` - Invalid individual
9. `IllegalGenoTypeException` - Invalid gene type
10. `UnknownGenoTypeException` - Unrecognized gene type
11. `NotInitializedException` - Component not initialized

---

## Extending the Library

### Creating a New Problem Model

1. **Define Fitness Algorithm**:
```csharp
public class MyFitnessAlgorithm : AbstractFitness
{
    public override double CalculateFitness(Individual individual)
    {
        // Your fitness logic
    }
}
```

2. **Create Model Class**:
```csharp
public class MyGAModel : AbstractGAModel
{
    public MyGAModel()
    {
        this.IndividualModel = new BinaryIndividualModel(geneLength);
        this.FitnessAlgorithm = new MyFitnessAlgorithm();
        this.SelectionAlgorithm = new TournamentMethod(2);
        this.SurvivalAlgorithm = new EliteStrategy(0.95);
        this.CrossoverAlgorithm = new TwoPointCrossover();
    }
}
```

3. **Run Algorithm**:
```csharp
var model = new MyGAModel();
var ga = new GeneticAlgorithm(model);
var result = ga.Search();
```

### Adding New Algorithm Components

**New Selection Algorithm**:
```csharp
namespace jp.co.tmdgroup.common.GeneticAlgorithm.Selections;

public class MySelection : AbstractSelection
{
    public override List<Individual> SelectIndividuals(
        List<Individual> group,
        int selectNumber)
    {
        // Your selection logic
    }
}
```

**New Crossover Algorithm**:
```csharp
namespace jp.co.tmdgroup.common.GeneticAlgorithm.Crossovers;

public class MyCrossover : AbstractCrossover
{
    public override Individual DoCrossover(
        Individual parent1,
        Individual parent2)
    {
        // Your crossover logic
    }
}
```

---

## AI Assistant Guidelines

### When Working on This Codebase

1. **Respect Japanese Comments**: Preserve existing Japanese documentation. When adding new comments, follow the existing language pattern of the file.

2. **Namespace Awareness**: Always use the full namespace `jp.co.tmdgroup.common.GeneticAlgorithm.*` when creating new files.

3. **Interface-First Design**: When adding features:
   - Define interface first (prefix with 'I')
   - Create abstract base class if shared logic exists
   - Implement concrete classes

4. **Exception Handling**: Use custom exceptions from the `Exceptions` namespace. Don't introduce generic .NET exceptions where specific ones exist.

5. **Thread Safety**: The `GASearchContext` is synchronized. Respect this pattern when adding concurrent features.

6. **No External Dependencies**: The core `GeneticAlgorithm` library has ZERO dependencies. Keep it that way unless absolutely necessary.

7. **Nullable Reference Types**: All projects have nullable enabled. Mark reference types appropriately:
   - `Type?` for nullable
   - `Type` for non-nullable
   - Use `= null!` when initialized later

8. **Testing New Features**:
   - Run the NQueenGASample to verify core algorithm changes
   - Create focused unit tests if test project exists
   - Document expected behavior in comments

9. **Folder Placement**:
   - New core features → `GeneticAlgorithm/GeneticAlgorithm/`
   - Legacy modifications → `GeneticAlgorithm/geneticalgorithm/`
   - Sample code → Keep in NQueenGASample

10. **Commit Practices**:
    - Use Japanese for commit messages (follow repository pattern)
    - Keep commits focused and atomic
    - Reference issue numbers if applicable

### Common Pitfalls to Avoid

1. **Don't** mix `geneticalgorithm/` and `GeneticAlgorithm/` components arbitrarily
2. **Don't** add NuGet packages to core library without discussion
3. **Don't** break the IGAModel abstraction
4. **Don't** ignore the existing exception hierarchy
5. **Don't** assume Windows-only (core library is cross-platform)
6. **Don't** remove Japanese comments - they contain important documentation

### Quick Reference Commands

```bash
# Build and run
dotnet build && dotnet run --project NQueenGASample/NQueenGASample.csproj

# Clean solution
dotnet clean CS_GA_DEV.sln

# Restore dependencies
dotnet restore

# Check for warnings
dotnet build /warnaserror

# Publish release
dotnet publish -c Release
```

---

## Performance Characteristics

- **Population Size**: Configurable via `IGAModel.IndividualModel`
- **Generation Gap**: Default 0.95 (5% elite survival)
- **Mutation Rate**: Typically `1.0 / geneLength`
- **Inverse Rate**: Usually 0.0 (disabled)
- **Search Methods**: Time-based, generation-based, or hybrid

**Typical N-Queen Performance** (N=8):
- Population: 200 individuals
- Generations: ~50-200 to find solution
- Time: Milliseconds on modern hardware

---

## Troubleshooting

### Build Errors

**Error**: `The type or namespace name 'jp' could not be found`
- **Solution**: Rebuild solution, ensure project references are correct

**Error**: WebView2 runtime missing
- **Solution**: Install Microsoft Edge WebView2 Runtime for NQueenGASample

### Runtime Issues

**Issue**: GA doesn't converge
- Check fitness function returns correct values
- Verify mutation rate isn't too high (try `1.0/geneLength`)
- Ensure elite strategy preserves good individuals
- Increase population size or generations

**Issue**: Stack overflow
- Check for recursive fitness calculations
- Verify gene size isn't excessive

---

## Future Enhancements

Consider these when extending the library:

1. **Testing**: Add comprehensive unit test project
2. **Algorithms**: Implement additional selection methods (Roulette, Rank)
3. **Parallelization**: Parallel fitness evaluation
4. **Persistence**: Save/load GA state for long-running optimizations
5. **Visualization**: Real-time convergence plotting
6. **Documentation**: English translation of comments
7. **Examples**: More problem samples (TSP, Knapsack, Job Scheduling)

---

## Resources & References

### Original Author
- **Author**: 森本寛 (Hiroshi Morimoto)
- **Company**: 株式会社東京マイクロデータ (Tokyo Micro Data Corporation)
- **Copyright**: 2002

### Documentation
- .NET 8.0 Documentation: https://learn.microsoft.com/en-us/dotnet/
- Genetic Algorithms Theory: Standard GA textbooks
- Windows Forms: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/

---

## Contact & Maintenance

This is a production-ready library maintained in Japanese. When contributing:

- Respect the original architecture and patterns
- Maintain backward compatibility
- Document changes in both English and Japanese where appropriate
- Follow the established code style

For questions about GA algorithms, refer to the detailed Japanese comments in the source code - they contain extensive theoretical explanations.

---

**Last Updated**: 2025-11-17
**Version**: Based on commit `010afea`
