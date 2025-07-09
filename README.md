Application full-stack de boutique en ligne développée avec :

 Backend : ASP.NET Core Web API (.NET 8)
 
  Frontend : Angular 16

[ Fonctionnalités principales]

 [Backend]
 
   Authentification par JWT (login, inscription, profil)
   
   Gestion des utilisateurs (CRUD)
   
   Catalogue de produits (par catégorie, ajout, suppression, mise à jour)
   
   Commandes (création, ajout de produit, historique)
   
   Protection via [Authorize] et [Authorize(Roles = "Admin")]
   
   Vérification CAPTCHA Google
 
 Limitation d’accès par IP (Rate Limiting)

 [Frontend (Angular)]
 
   Interface responsive utilisateur
   
   Authentification JWT
   
   Navigation produits, panier, commandes
   
   Appels API avec gestion des tokens JWT

[ENDPOINTS DISPONIBLE]

   [AUTH]
   
   /api/auth/register --> Créer un utilisateur
   
   
   /api/auth/login --> Connexion, retourne un JWT
   
   
   /api/auth/profil --> Récupère le profil de l'utilisateur
   
   
   /api/auth/GetAll --> Liste des utilisateurs
   
   
   /api/auth/{id} --> Mise à jour du profil utilisateur
  
   [PRODUCTS]
   
   /api/product/AddProduct --> Ajout d’un produit
   
   
   /api/product/GetAll --> Liste tous les produits
   
   
   /api/product/productsByCategory/{category} --> Produits par catégorie
   
   
   /api/product/GetProduct/{id} --> Détails d’un produit
   
   
   /api/product/Update/{id} --> Met à jour un produit
   
   
   /api/product/Delete/{id} --> Supprime un produit

 [ORDER]
 
 /api/order/CreateOrder --> Crée une commande
 
 
 /api/order/AddProductInOrder --> Ajoute un produit à une commande
 
 
 /api/order/GetOrder/{id} --> Récupère une commande par ID
 
 
 /api/order/GetActiveOrder/{id} --> Commande active de l'utilisateur
 
 
 /api/order/GetOrdersByUserId --> Liste les commandes d'un utilisateur
 
 
 /api/order/UpdateStatus/{id} --> Mise à jour du statut (admin)
 
 [CAPTCHA]
 
 /api/captcha/verify --> Vérifie le token Google Captcha


[SWAGGER & JWT]

Swagger est activé en mode development  --> URL : https://localhost:5001/swagger

Authentification JWT : utiliser le bouton “Authorize” en haut pour fournir un Bearer Token

[PROGRAMME PRINCIPAL]

Authentification JWT avec validation des rôles

CORS autorisé pour http://localhost:4200

Swagger génère un schéma sécurisé avec Bearer Token

Configuration du rate-limiting via AspNetCoreRateLimit
