# AI-FSM

## How AI behaviors influence player strategy and decision-making

When a game has AI behaviours, players are faced with more challenge and intensity within gameplay. Having a smart enemy makes the player think outside the box, which allows for them to create patterns to counter the AI. This forces the player to adapt, and find different strategies that work for them, whether it be remaining completely stealthy or aggressive. Over time, players will recognize how the AI works and what types of behaviours it has. For example, the Xenomorph in Alien Isolation will learn how the player behaves, and the player must navigate different strategies to counteract the Alien. However, players will have to rethink their tactics in certain scenarios and gather more information on the state of the Alien in order to master it over time. 


## How player actions dynamically alter AI states and responses

In this demo, the AI only reacts to the player and the AI follows them once detected. When the player is behind a wall, the enemy goes back to its stationary patrol state. In other games, the AI can can pick up on noise and the last known location of the player, encouraging a stealthier approach to the gameplay. For example, players may be able to distract the AI by throwing a stone or bottle to a location, making the AI enter its suspicious or investigative state. Games such as Hitman will have enemies that alert other guards and heighten the overall awareness of Agent 47's presence throughout the map as well.  


## Challenges faced during implementation and solutions

The first real trouble was having the AI chase the player, as when tested in game the AI wouldn't detect the player and just keep rotating. To fix this, I add a Debug.DrawLine that would visualize the raycast. The collision of the AI was blocking the raycast from extending towards its initial view distance. I wasn't able to get it to work without disabling the collider on the AI. I also had troubles with getting the AI to go to the players last known location, which I couldn't find a fix for in time.  
