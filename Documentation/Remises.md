# Remises

| Date     | Élément de la remise                                                                                | Pondération |
|----------|:----------------------------------------------------------------------------------------------------|-------------|
| 31 mars  | Diagramme de classe préliminaire<br/>Dictionaire de classes<br/>Diagramme de séquence prééliminaire | 20%         |
| 14 avril | Code source commenté<br/>Exécutable fonctionnel<br/>Démo<br/>Rapport final                          | 80%         |

## Rapport final

Votre rapport final qui accompagnera la remise de votre exécutable devra inclure les éléments suivants :

- Diagramme de classe final (Avec modifications)
- Diagrammes de séquences ajustés (2)
- Dictionnaire de classe mis-a-jour
- Réflexion sur votre conception

### Réflexion sur votre conception

Afin de démontrer que vous avez appliqué les principes de conception GRASP et le patron MVC, rédigez une courte analyse
de votre conception.

Cette analyse devrait expliquer vos principales décisions de conception et comment elles améliorent votre logiciel. Vos
explications devraient faire références aux différents principes couverts en classe.

## Fonctionnalités du jeu d’échecs

Voici la liste des fonctionnalités qui devraient être incluse dans votre logiciel :

- Voir la liste des joueurs et leurs scores enregistrés dans le fichier texte
- Ajouter/Supprimer joueurs
- Démarrer une partie en choisissant 2 joueurs
- Jouer un coup
    - Coup invalide
        - Mouvement impossible pour la pièce
        - Collision
        - Mouvement qui met en échec
        - Coup valide
            - Mouvement normal
            - Mouvement spécial (charge, roque, prise en passant)
            - Attaque d’une pièce ennemie
            - Promotion du pion
            - Échec
- Fin de partie
    - Échec et mat
    - Échec et pat
    - Nulle avec entente
    - Nulle « boucle infinie »
- Ajustement et enregistrement des scores des joueurs
- Doit pouvoir jouer plus d’une partie simultanément