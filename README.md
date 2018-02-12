# Smart-Cars-2D
Cars that drive automatically in almost any given path. They automatically adjust their speed and rotation!

# Steps:
Clone the project itself and open it in Unity.

# How to build your own level:
In order for the cars to work you need to add 2D colliders to the walls and put them in the "Default" layer. In case you want to put them in another layer just enable the needed layer in the CarController.cs script in the IgnoreCarsMask in the inspector that exists in every Car.
After that just put as many cars as you want inside the road!

**Warning:** Try not to leave any blank space in the walls as this may cause problems with the raycast and the distance calculation (See *Approach to get this result*)

# Notes:
1) There are 2 example scenes located at Assets/Resources/Scenes. Their names are First.unity and Second.unity
Just open one of them and press play. They will automatically start racing!
2) Cars by default ignore other cars to get a nicer path. You can change that by enabling the CarLayer
3) Increasing the scale of the car is expected to cause problems in the driving.

# Approach to get this result:
1) Each car contains a GameObject called "Raycasters" taht contains its raycasts. There are 6 raycasts in total per car. 2 are looking forward, 1 is left, 1 is right, 1 is up-left and the last one is up-right. Each of those raycasts calculates the distance to the wall and thus gives the car info about how to turn and how to reduce/increase the speed.
2) The reason there are 2 forward raycasts is for calculating the angle of the wall in front so that it can know whether to turn left or right.
3) Left, right, up-left, up-right raycasts are used to keep the car in the middle of the road. They work by trying to keep the distance between them the same. For example, if the distance to the left is 2 and the distance to the right is 1 then the car will try to turn a bit on the left in order to balance the difference of the distances.
4) The speed of the car is determined by how small or big the forward distance is.
