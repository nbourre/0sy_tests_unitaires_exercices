# Exercices de révision sur les tests unitaires
Voici quelques exercices qui vont vous aider pour l'éventuel évaluation sur ce sujet.

## Scénario
Vous êtes attitré à un projet de développement d'un système de récensement des espèces écologiques. Le système doit extraire les données d'un fichier Excel source vers un autre fichier Excel. Le projet C# est déjà débuté et il utilise le package Nuget ClosedXML pour gérer les fichiers Excel.

Le fichier **liste_especes.xlsx** est un fichier qui respecte tous les requis.
- Prenez le temps de regarder le contenu du fichier Excel

## Requis du domaine
- Il doit y avoir une feuille nommée **especes** dans le fichier d'entrée.
- La feuille **especes** doit avoir les trois colonnes suivantes en ordre : *Nom*, *Nom latin* et *Habitat*.
- Les majuscules et minuscules ne doivent pas être pris en compte pour les noms de colonnes.
- Si la structure n'est pas valide, le message d'erreur "***Mauvais format de fichier!***" dans la propriété `Message` de la classe `MainViewModel`

## Requis applicatifs
L'application doit être en mesure de charger un fichier Excel.

**Pour être valie un fichier Excel doit :**
- Exister. Sinon afficher le message "***Fichier inexistant!***" à l'utilisateur.
- Être de format Excel. Sinon afficher le message d'erreur "***Mauvais format de fichier!***" dans la propriété Message.

## Ce qui doit être fait

### Créer des jeux de données à tester
**MemberData**
- Une liste de fichiers qui existe valide ou non;
- Une liste de fichiers Excel;
- Une liste de fichier qui n'existent pas;
- Une liste de fichier de mauvais type.

**ClassData**
- Une liste de fichiers Excel de mauvais format;
- Une liste de fichiers Excel qui répond aux requis;

### Tester **`LoadContentCommand()`**
- [Theory] Si le fichier existe `CanExecute` devrait retourner vrai;
- [Theory] Si le fichier n'existe pas `CanExecute` devrait retourner faux;
- [Theory] Si le fichier n'existe pas, le message devrait être `"Fichier inexistant!"`;
- [Theory] Si le fichier est dans un mauvais format, le message `"Mauvais format de fichier!"` devrait être affiché;
- [Theory] **ClassData** : Si le fichier Excel est dans un mauvais format, le message `"Mauvais format de fichier!"` devrait être affiché;
- [Theory] **ClassData** :Si le fichier Excel est valide, `FileContent` ne devrait pas être vide.

### Tester **`ValidateExcelCommand()`** 
- [Theory] Si le fichier Excel n'a pas les bonnes entêtes, le message devrait être `"Contenu du fichier Excel non reconnu"`

### Tester la classe **`EspeceXL()`**
- [Theory]  **ClassData** : La méthode `GetCSV` devrait retourner une chaîne non vide si le contenu du fichier est valide.
- [Theory]  **ClassData** : La méthode `GetCSV` devrait déclencher une erreur `ArgumentException` si le contenu du fichier n'est pas valide.
- [Fact] `LoadFile` devrait déclencher une erreur `ArgumentException` s'il n'y a pas de fichier.
- [Theory] **InlineData** : `LoadFile` devrait déclencher une erreur `ArgumentException` si le fichier n'est pas valide.


# Annexe
## Rappel - DelegateCommande
- Pour exécuter une commande, il faut appeler la méthode `Execute(T param)`
  - Exemple : `MaCommande.Execute(string.empty)`
- Pour vérifier si la commande peut être exécutée, il faut appeler la méthode `CanExecute(T param)` qui retournera un booléen.
  - Exemple : `var result = MaCommande.CanExecute(string.empty)`



## Code fourni
Dans la classe pour tester le `MainViewModel`, ajoutez le constructeur , les membres et la méthode ci-contre :

```cs
/// Dossier contenant les fichiers
string excelFilesPath;

/// Référence pour le ViewModel à tester
MainViewModel vm;

public MainViewModelTests()
{
    vm = new MainViewModel();

    Uri codeBaseUrl = new Uri(Assembly.GetExecutingAssembly().Location);
    var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
    var dirPath = Path.GetDirectoryName(codeBasePath);

    /// Va chercher le dossier Data à partir du dossier de compilation
    /// ce code s'adapte selon l'emplacement du projet.
    excelFilesPath = Path.Combine(dirPath, @"..\..\..\..\..\data");
}

/// Permet de remettre à zéro certain champ du VM
private void resetData()
{
    vm.InputFilename = "";
}
```

Dans la classe pour tester le `EspeceXL`, ajoutez le constructeur et les membres ci-contre :

```cs
/// Dossier contenant les fichiers
string excelFilesPath;

public MainViewModelTests()
{
    Uri codeBaseUrl = new Uri(Assembly.GetExecutingAssembly().Location);
    var codeBasePath = Uri.UnescapeDataString(codeBaseUrl.AbsolutePath);
    var dirPath = Path.GetDirectoryName(codeBasePath);

    /// Va chercher le dossier Data à partir du dossier de compilation
    /// ce code s'adapte selon l'emplacement du projet.
    excelFilesPath = Path.Combine(dirPath, @"..\..\..\..\..\data");
}
```

## Autre code d'intérêt
Pour combiner des chaînes de caractères pour construire un chemin
```cs
Path.Combine(chemin_dossier, nom_fichier);
```

Pour extraire l'extension d'un fichier. Attention! Cela inclut le point.

```cs
var ext = Path.GetExtension(nom_fichier);
if (ext != ".pdf") {
  // Message de mauvais type de fichier
  return;
}
```
