# Exploring interaction mechanisms and perceived realism in different Virtual Reality shopping setups

**Table of content:**
 - [Abstract](#abstract)
 - [CSV files structure](#csv-files-structure)
 - [Post experiment questionnaire](#Post-experiment-questionnaire)
 - [Interaction mechanisms formalization](#interaction-mechanisms-formalization)
 - [Mathematical representation of some variables in the formalization](#mathematical-representation-of-some-variables-in-the-formalization)

<a id="item-one"></a>
## Abstract
Within the e-commerce field, disruptive technologies such as Virtual Reality (VR) are beginning to be used more frequently to explore new forms of human-computer interaction in the field and enhance the shopping experience for users. Key to this are the increasingly accurate hands-free interaction mechanisms that the user can employ to interact with virtual products and the environment. In addition, these products must be sufficiently realistic to be attractive to the user to initiate these interactions. This study presents an experiment with a set of participants that will address: (1) the impact of presenting realistic 3D models, (2) users’ evaluation of a set of pre-formalised interaction mechanisms, (3) preference for a large-scale or small-scale shopping environment and how the degree of usability while navigating the large-scale one, and (4) the usefulness of monitoring user activity to infer user preferences. The results provided show i) a high level of realism with low-cost digitization technologies, ii) interaction mechanisms realized with users’ hands are fluid and natural, iii) high usability in small and large shopping spaces, iv) finally, the recorded interaction can be employed for user profiling that improves future shopping experience

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
## Post experiment questionnaire
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

<a id="item-four"></a>
## Interaction mechanisms formalization
These interaction  mechanisms are largely implemented in the [Meta XR All-in-one SDK](https://developer.oculus.com/documentation/unity/unity-isdk-architectural-overview/), and will be used for users to interact with the environment and products in the application developed for the experiment detailed.

### Formalization of elements for performing interactions
The interactions registered are those performed by the user with its hand. Las siguientes variables representan una breve formalización de las interacciones que el usuario puede llevar a cabo en un entorno de compra virtual, tal y como se planteará la aplicación usada en el el experimento que se describe en la Section \ref{sec:setup}. A continuación, vamos a describir los elementos que juegan un rol importante en las interacciones que serán detalladas, teniendo en cuenta la siguiente clasificación: elementos relacionados con el usuario y elementos del entorno virtual.

#### User-intrinsic elements

The shopper or user $U$ in the environment initiates each possible interaction with their surroundings or products. The virtual representation of the left and right hands consists of a set of articulated segments representing the fingers $Fi = {f_1, f_2, ..., f_n}$ with colliders\footnote{Components of the Unity physics engine that envelop an object and allow for the detection of intersections and collisions in a 3D space.} to interact with objects and the environment. The position and orientation of each segment are defined by its position vector $p_{fi} = (x_{fi}, y_{fi}, z_{fi})$ and orientation vector $o_{fi} = (\theta_{fi}, \phi_{fi}, \psi_{fi})$, where $\theta_{fi}$, $\phi_{fi}$, $\psi_{fi}$ are the rotation angles on the X, Y, Z axes, respectively. Additionally, the palm and wrist are formalized by their own position and orientation vectors, $p_{palm}$, $o_{palm}$, $p_{wrist}$, $o_{wrist}$, as they are necessary for the configuration of gestures that can be detected with hand tracking. On the other hand, we have the head and eyes, defined by their own position and orientation vectors $p_{head}$, $o_{head}$ and $p_{eye}$, $o_{eye}$ for each eye. Fig. \ref{fig:esquema-mano} shows the formalisation of the spatial information described above about the users' hands, which is easily extrapolated to the eyes or the head.

#### Elements specific to the virtual environment
In the virtual shopping environment $E$, two types are distinguished for use in the experiment: $E_s$, a smaller-sized environment featuring a single counter $Counter_x$ with products from categories $Ca = {ca_1, ca_2, ca_3, ..., ca_n}$, and $E_l$, a larger environment simulating a real shopping space. $E_l$ comprises several sections $S = {s_1, s_2, s_3, ..., s_n}$, each corresponding to a product category from $C$. Each section $s_i$ includes one or several counters from $Counter = {cou_1, cou_2, ..., cou_n}$, with $cou_i$ exclusive to a specific section $s_i$. The boundaries of each section are defined by the dimensions of its collider $Co_i = (X, Y, Z)$ on each axis, thereby delineating teleportation and movement limits for the user throughout $E_l$. A counter $counter_i$ displays an assortment of products from the environment's total offering, $Pr = {pr_1, pr_2, pr_3, ..., pr_n}$. Each product $pr_i$ is characterized by its position vector $Pr_p = (x_{pr}, y_{pr}, z_{pr})$, orientation vector $o_{pr} = (\theta_{fi}, \phi_{fi}, \psi_{fi})$, and collider. For simplicity and to ensure application performance provides a enjoyable user experience, we consider Unity's colliders in basic primitive forms: a parallelepiped or box (defined by the position vector of its center and its dimensions on each axis), a sphere (defined by the position vector of its center and its radius), and a capsule (defined by the position vector of its center, its radius, and its height).

Furthermore, the environment includes a shopping cart $Sc$, whose behaviour varies depending on the setting. In $E_s$, the shopping cart $Sc_s$ is characterized by dimensions of length $l$, width $w$, height $h$, and the position of the cart's center $p_sp = (x_s, y_s, z_s)$, remaining static beside the user $U$. Conversely, in $E_l$, the shopping cart $Sc_l$, similarly characterized, stays beside the user at the same distance as in $E_s$, even when $U$ teleports from an initial point $P_i = (x_i, y_i, z_i)$ to a final point $P_f = (x_f, y_f, z_f)$. The cart's center moves a distance $D = \sqrt{(x_f - x_i)^2 + (y_f - y_i)^2 + (z_f - z_i)^2}$. The use of a virtual shopping cart, investigated and implemented in various prototypes, enhances the realism \cite{mostafa_impact_2023-1,siegrist_consumers_2019}. However, to avoid the tedium of physically moving a cart in a store, this solution was chosen to reduce the user's cognitive load, eliminating the need to be mindful of where to move and leave the cart.

### Formalization of interaction mechanisms
Next, we will formalize the interaction mechanisms that the user $U$ can perform with the virtual shopping environment $E$ and its products $Pr$, which will be used in the prototype for the experiment described in the following section. First, let us consider that $h$ represents a hand (left hand $h_l$ or right hand $h_r$) in the virtual space, and $pr_i$ is a product. The interaction mechanisms described below are grouped into: mechanisms requiring hand use with objects (grabbing, translating, rotating, and scaling), mechanisms for interacting with the virtual environment including objects (teleporting, gesture detection, and adding a product to the shopping cart), and mechanisms involving the eyes (looking). The formalization is presented in the form of mathematical functions that return 1 if the interaction occurs, meeting the necessary conditions.

#### Mechanisms requiring the use of hands with objects
**Grabbing**. Let $h$ be either the left hand $h_l$ or the right hand $h_r$, and $pr_i$ any product such that $pr_i \in Pr$. Then, $G(h,pr_i) = 1$ if product $pr_i$ is grabbable, it is sufficiently close to $h$, and the position and orientation vectors of the fingers $Fi$, the palm, and the wrist meet the grip type defined for the product $pr_i$ from the SDK options. Proximity is determined by the distance between the boundaries defined by the colliders at the tips of the fingers of $Fi$, which are permitted by the grip rules, and those of the collider of the product $pr_i \in Pr$ itself. Fig. \ref{fig:hand-poses} shows one of the hand poses that allows one to grab an object.

**Translating**. $T(h, pr_i,\Delta p, \Delta s, \Delta Tr) = 1$ if product $pr_i \in Pr$ is grabbed by hand $h$ and is moved by hand $h$ according to the vector of change in the product's position ($\Delta p$), or the vector of change in a part of the product's position ($\Delta s$, for instance, opening a box cover), and the transformation matrix $\Delta Tr$.

**Rotating**. $R(h,pr_i,\Delta R) = 1$ if product $pr_i$ is grabbed by hand $h$ and rotated $\theta_x, \theta_y, \theta_z$ degrees by hand $h$ according to the transformation matrix representing the change in the object's orientation ($\Delta R$). It is important to note that the rotation angles can be restricted, establishing a minimum and maximum, as well as the axes on which rotation can be performed.

**Scaling**. $S(h,pr_i,\Delta d) = 1$ if product $pr_i$ is grabbed by hand $h$ and scales according to the vector of change in the dimensions of the product ($\Delta d$) and the transformation matrix $\Delta Tr$.

#### Mechanisms for interacting with the virtual environment

**Teleport**. Teleportation is a form of navigation in VR environments, which allows users to traverse these spaces without needing large physical areas, and it is also a technique that does not induce motion sickness \cite{teleport_comparative_evaluation}. Let $P_i = (x_i,y_i,z_i)$ be the current position of the user $U$, and let $P_f = (x_f,y_f,z_f)$ be one of the positions to which the user wishes to teleport, considering that $P_i$ and $P_f$ are within colliders to which the user can teleport. As the user must point with his index finger to $P_f$ and make the pinch gesture to trigger the teleport, let $P_g$ be the position of this finger, $d = y_g$ the distance from it to the floor, and $D_p$ the unit vector of the finger's direction. The arc allowing the user to point to $P_f$ is $P_a(t) = P_g + t\times D_p + f(d,t)\times k$, where $t$ ranges from 0 to the maximum length of the arc, $f(d,t)$ is a function for the curvature of the arc, and $k$ is the vertical direction unit vector. When $P_f=P_a(t)$ and the user performs the pinch gesture, teleportation is triggered. Fig. \ref{fig:hand-poses} shows the hand pose to invoke the arc to perform a teleport.

**Add to Shopping Cart**. $A_g(h,Sp,pr_i) = 1$ if the user $U$ adds the product $pr_i \in Pr$, grabbed with their hand $h$, to the shopping cart $Sp$. Tthe product $pr_i$ will be placed within the volume defined by the parallelepiped, whose top face is open. Therefore, as the shopping cart is moved, the objects will remain in the same relative position within the cart.   %Para los productos estáticos, la interacción se formalizaría como $A_r(h,Ca,pr_i) = 1$ si el usuario $U$, hace el gesto de pinch con la punta de los dedos pulgar e índice de $h$ apuntado con un rayo $Ray(f_{thumb},f_{index})$ al Canvas $Ca$ que contiene un botón de interfaz de usuario. De esta forma, el rayo que tiene en cuenta la posicion y orientación de dichos dedos, al colisionar con la superficie de $Ca$, permitirá la interacción con dicho botón para añadir el producto al carrito.

#### Mechanisms involving the eyes
**Looking**: $Eye$ represents either of the two eyes, the left $Eye_l$ and the right $Eye_r$. Let $L_e(Eye, pr_i) = 1$ if $Ray(p_{eye}, o_{eye})$ collides with the product $pr_i$ and it is within a layer that $Ray(p_{eye}, o_{eye})$ can collide with. The ray $Ray$ is projected along the Z-axis for a parametrizable distance $d_{ray}$. If the two rays emitted from $Eye_l$ and $Eye_r$ simultaneously collide with the same $pr_i$, it is only counted once, the same as if it is collided with by just one of the rays. In the absence of an HMD with eye tracking, the position and rotation of the head (of the HMD) will be used to cast the rays $Ray(p_{eye}, o_{eye})$.

All these interactions have their technological implementation, whether through software components provided by the Meta package, such as the position and orientation of various elements like the hands and eyes, or custom implementations, such as the parametrization of interactions or raycasting from the eyes to detect which objects are being looked at. Thanks to this, we can track and monitor user activity in the virtual environment, which can help infer their tastes and preferences, thereby enhancing the shopping experience.

<a id="item-five"></a>
## Mathematical representation of some variables in the formalization

For **translating** interaction: 

```math
\Delta Tr = \begin{bmatrix}
r_{11} & r_{12} & r_{13} & \Delta p_x \text{ (or } \Delta s_x\text{)} \\
r_{21} & r_{22} & r_{23} & \Delta p_y \text{ (or } \Delta s_y\text{)} \\
r_{31} & r_{32} & r_{33} & \Delta p_z \text{ (or } \Delta s_z\text{)} \\
0 & 0 & 0 & 1
\end{bmatrix}
```

For **rotating** interaction. The first three matrices represent the rotation matrix for each of the axis indicated (X,Y,Z), and the last one is the final product of the rotation matrices:

```math
% Matriz de rotación alrededor del eje X
R_x(\theta_x) = \begin{bmatrix}
1 & 0 & 0 \\
0 & \cos(\theta_x) & -\sin(\theta_x) \\
0 & \sin(\theta_x) & \cos(\theta_x)
\end{bmatrix}

% Matriz de rotación alrededor del eje Y
R_y(\theta_y) = \begin{bmatrix}
\cos(\theta_y) & 0 & \sin(\theta_y) \\
0 & 1 & 0 \\
-\sin(\theta_y) & 0 & \cos(\theta_y)
\end{bmatrix}

% Matriz de rotación alrededor del eje Z
R_z(\theta_z) = \begin{bmatrix}
\cos(\theta_z) & -\sin(\theta_z) & 0 \\
\sin(\theta_z) & \cos(\theta_z) & 0 \\
0 & 0 & 1
\end{bmatrix}

% Producto final de las matrices de rotación
\Delta Tr = R_z(\theta_z) \cdot R_y(\theta_y) \cdot R_x(\theta_x)
```

For **scaling** interaction: 
```math
\Delta Tr = \begin{bmatrix}
d_x & 0 & 0 & 0 \\
0 & d_y & 0 & 0 \\
0 & 0 & d_z & 0 \\
0 & 0 & 0 & 1
\end{bmatrix}
```

