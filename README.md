# Exercices de révision sur les tests unitaires
Voici quelques exercices qui vont vous aider pour l'éventuel évaluation sur ce sujet.

## Scénario
Vous êtes attitré à un projet de développement d'un système de récensement des espèces écologiques. Le système doit extraire les données d'un fichier Excel source vers un autre fichier Excel. Le projet C# est déjà débuté et il utilise le package Nuget ClosedXML pour gérer les fichiers Excel.

Le fichier **liste_especes.xlsx** est un fichier qui respecte tous les requis.

## Requis du domaine
- Il doit y avoir une feuille nommée **especes** dans le fichier d'entrée.
- La feuille **especes** doit avoir les trois colonnes suivantes en ordre : *Nom*, *Nom latin* et *Habitat*.
- Les majuscules et minuscules ne doivent pas être pris en compte pour les noms de colonnes.
- Si la structure n'est pas valide, le message d'erreur "***Mauvais format de fichier!***" dans la propriété `Message` de la classe `MainViewModel`

## Requis applicatifs
L'application doit être en mesure de charger un fichier Excel.
**Un fichier Excel pour être valide**
- Le fichier doit exister. Sinon afficher le message "***Fichier inexistant!***" à l'utilisateur.
- Le fichier doit être de format Excel. Sinon afficher le message d'erreur "***Mauvais format de fichier!***" dans la propriété Message.

## Ce qui doit être fait
Vous devez faire les tests pour :
- la méthode **ValidateExcel()**.
- Le constructueur **EspeceXL()**
- Les différentes méthodes de la classe **EspeceXL**

