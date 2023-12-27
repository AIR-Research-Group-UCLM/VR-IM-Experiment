# Exploring interaction mechanisms and perceived realism in different Virtual Reality shopping setups

**Table of content:**
 - [Abstract](#item-one)
 - [CSV files structure](#item-two)
 - [Post-experiment questionnaire](#item-three)

<a id="item-one"></a>
## Abstract


 
<a id="item-two"></a>
## CSV files structure
The headers of the files under the "csvFiles" directory are listed below:

- ProductInteractionData.

  - Timestamp - a timestamp in seconds starting from the start of the game session.
  - Object - name of the product being interacted with.
  - Interactable - Meta SDK class to know the origin of the interaction.
  - Position - position in global coordinates of the object, a header for each axis (X,Y,Z).
  - Rotation - degrees of rotation of the object, one header for each axis (X,Y,Z).
  - Scale - scale in meters, one header for each axis (X,Y,Z).

- ShoppingCartData.

  - Timestamp - same function as in the previous file.
  - ItemAdded - the name of the product added to the cart.

- EyeTrackingData.

  - Timestamp - same function as in the first file.
  - Object - the name of the product added to the cart.
  - Section - section in which the product is located.
  - Duration - duration of the collision of the projected beam from the eye colliding with the product.
  - EyeLeftPosition, EyeLeftRotation, EyeRightPosition, EyeRightPosition - position and rotation of the eyes provided by the Meta SDK, one header for each axis (12 headers in total).
  
- TeleportData.

  - Timestamp - same function as the first file described.
  - TPHotspot - name of the collider that has been pointed to, to know where it is moving within the environment.
  - HMD - position in global coordinates of the VR hull, one header for each axis (X,Y,Z).
  - Duration - duration from when the collider was selected until teleportation occurred.
  - WasTP - indicates whether the collider selection ended with a teleportation or not. For example, the user could have had problems performing the gesture and ended up performing it outside the teleport zone.

For the second scene, the first three .csv files were stored, while for the third scene all four .csv files were generated, giving a total of seven files for each participant. In the following section, the results obtained after analysing the data obtained from the experiment, both at the level of the questionnaire and the recorded data, will be presented.

<a id="item-three"></a>
## Post-experiment questionnaire
The scale of the questions was usually from 1 to 5, with 1 being the negative extreme (Very little, I liked it very little, not at all, ...), 3 the neutral answer and 5 the positive extreme (Very much, I liked it very much, frequently, ...). Questions 24 and 25 refer to the product sections within the large environment used in the third scene: 1 - food, 2 - toys, 3 - technology, 4 - fashion, 5 - decoration.
| **ID** | **Question**                                                                                    | **Rating Scale** |
|--------|-------------------------------------------------------------------------------------------------|------------------|
| **1**  | How realistic did you find the scanned objects?                                                 | 1-5              |
| **2**  | Would you prefer this type of model over 2D images?                                             | 1-5              |
| **3**  | If you were presented with a product you want to buy in this way, how likely are you to purchase it? | 1-5              |
| **4**  | I would use this technology to shop frequently                                                  | 1-5              |
| **5**  | I believe the environment is easy to understand and use                                         | 1-5              |
| **6**  | I believe most people would understand how to use this environment                              | 1-5              |
| **7**  | Would your purchase intention change after examining an object compared to just seeing a 2D image? | 1-5              |
| **8**  | Rate the interaction with products using hands                                                  | 1-5              |
| **9**  | Rate the interaction with products using controllers                                            | 1-5              |
| **10** | Rate the use of the shopping cart                                                               | 1-5              |
| **11** | Rate the use of physics on products, to interact with them or add them to the cart              | 1-5              |
| **12** | Rate the use of the 'Add to Cart' button on static objects                                      | 1-5              |
| **13** | Rate how easy it was for you to add products to the cart                                        | 1-5              |
| **14** | Rate how easy it was for you to move around the large environment                               | 1-5              |
| **15** | Rate if the interactions seemed fluid and natural                                               | 1-5              |
| **16** | Do you prefer the small environment or the large one for future shopping in VR?                 | 1-2              |
| **17** | General discomfort                                                                              | 1-5              |
| **18** | Fatigue                                                                                         | 1-5              |
| **19** | Dizziness                                                                                       | 1-5              |
| **20** | I felt immersed and present in the virtual environment                                          | 1-5              |
| **21** | I had sensations similar to shopping in a physical store                                        | 1-5              |
| **22** | Time passed quickly for me in the application                                                   | 1-5              |
| **23** | I felt disoriented and lost in the application                                                  | 1-5              |
| **24** | What type of products do you buy most often?                                                    | 1-5              |
| **25** | Which of the sections do you find most useful for selling in VR?                                | 1-5              |
| **26** | Would you buy using VR in the future, more refined?                                             | 1-5              |
