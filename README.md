# CityDrive Manager 🚗💨

**CityDrive Manager** est une application console en C# permettant de gérer une flotte de véhicules, des points d'intérêt (POI) et de planifier des trajets urbains. Ce projet met en pratique les concepts fondamentaux de la Programmation Orientée Objet (POO).

## 🚀 Fonctionnalités

- **Gestion des Véhicules** : Ajout et affichage de voitures thermiques, camions, voitures hybrides et électriques.
- **Gestion des Lieux** : Création de points d'intérêt classiques, campus étudiants et monuments historiques.
- **Simulation de conduite** : Accélération et freinage avec gestion dynamique de la vitesse.
- **Système d'Énergie** : 
  - Gestion du carburant (Interface `IThermalCar`).
  - Gestion de la batterie (Interface `IElectricCar`).
  - Menu dédié pour faire le plein ou recharger les batteries avec contrôles de sécurité.
- **Planification de Trajets** : Calcul de distance entre deux points et estimation du temps de trajet basé sur une vitesse moyenne.
- **Système de plein** : Rajout d'un système permettant de faire le plein / recharger la voiture.

## 🛠️ Concepts POO utilisés

- **Héritage** : Spécialisation des classes `Vehicle` et `PointOfInterest`.
- **Interfaces** : Utilisation de `IThermalCar` et `IElectricCar` pour un découplage efficace des systèmes d'énergie.
- **Polymorphisme** : Surcharge de la méthode `ToString()` et redéfinition des méthodes `Accelerate()`/`Brake()`.
- **Encapsulation** : Propriétés avec getters/setters et validation des données de saisie.

## 📦 Installation et Lancement

1. **Prérequis** : Avoir installé le SDK .NET (6.0 ou supérieur).
2. **Cloner le projet** :
   ```bash
   git clone [https://github.com/SPA-guetty/CityDrive_Manager.git](https://github.com/SPA-guetty/CityDrive_Manager.git)
1. **Lancement** : Lancer le projet avec la commande "dotnet run".