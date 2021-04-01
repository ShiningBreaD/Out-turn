# Out-turn
Out-turn is simple 2D game about manufacturing control. This game was made for a hackathon.
This repo contains source code for this game for Unity.

# The idea
This game simulates the process of manufacturing control.
Player has 4 indicators of manufacturing, if one of them will drop below zero the game will end.
Gamplay is simlpe: 
Player must choose how to deal with one situation or another. Player choice will change value of one of the indicators (or a few of them)
The Game is endless and it saves your score

# How it works

-Class "Indicator" provides a way to control indicator variables and indicator UI

-Class "CardGravity" describes movement of the card, when player touches it

-Class "DeckManager" gives an opportunity to "CardInteractionmanager" to interact witn Indicators

-Class "CardInteractionManager" provides some UI animations betwen "Indicator", "DeckManager" and "CardGravity"

-Class "CardSetUpManager" contains all the infotmation about card

-Class "ChangedIndicatorsInfo" which provides information about what choices cards have

# License
This project is not licensed.
We welcome all developers to use this repo for their projects.
