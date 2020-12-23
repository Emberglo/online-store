# AmaZen
<img class="img-responsive" src="https://images.unsplash.com/photo-1472851294608-062f824d29cc?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&h=600&q=80">

Welcome to the AmaZen Dev team! AmaZen is a Chakra Cleansing shopping experience where voyagers can add their latest Zen products to our co-op to be sold. They can also create collections of all the chi enriching products to a wishlist to later review and to buy!  This is a totally unique application that will take the world by storm! Problem is we don't know how to build a website, or a server, or an A-Pea-eye? ...So that is where you come in!  We need your help building our dream. If completed to our specifications, when we launch you will be given an AmaZen `gift card**` worthy of your efforts. What an exciting opportunity no?

## Goals

In this checkpoint students will demonstrate a working knowledge of building full-stack applications. They will utilize a VueJs frontend using an AppState/observer pattern (`reactive`) to interact with the DOM. On the server side students will use a DotNet core web api utilizing the MVC design pattern, a MySQL Database hosted on GearHost, as well as implementing an Auth0 login to handle user profiles. Students will also be given a design mock that they will need to follow.
- [Figma Mock](https://www.figma.com/file/BHMu1rLH2lFEC13I6gYw5m/AmaZen-Mock?node-id=0%3A1)

## The Business Rules

AmaZen is a simple enough application, the store page should have listings for all the products that are available, selecting a product should give you a more detailed view of that product. From there a user can then add that product to one of their wishlists. A user can only edit/delete what they create.
When building AmaZen you consider the following `User Stories`:
 - as a User, I can browse all the available products without being logged in.
 - as a User, I can select a product and view it's details without being logged in.
 - as a User, I can create and account and become a member.
 - as a member, I can upload products to the store page.
 - as an owner of a product, I can edit or delete a product I have created.
 - as a owner of a product, I can mark a product 'un-available' without it being deleted.
 - as a member, I can browse all the products on a wishlist.
 - as an owner of a wishlist I can remove products from that list.

## The Setup
There is no single template that will give you everything you need this time around.  You will have to create the files for this project yourself, but to help you get started...

For the front end, students should use the **Vue-Starter** template from the `bcw-create` CLI tool.  Students will have to set up their own Auth0 environment variables here as well.

On the server side, you will want to set up your Auth0 and Database Variables as well. Starting development for AmaZen you will want to create some models. When doing this keep in mind the relationship between `products` and `wishlists`. You will need to manage the users `profile`, their `products`, `wishlists` and their respective relationship model(wishlistproduct, productwishlist) as well as the view model to go with it.

Members will be allowed to create `products` and then save those `products` and the  `products` of others in their `wish lists`.



## Requirements

- The Front End is styled and adheres to the design mock(this is a broad concept, but straying too far from the mock will upset the client)
- A user should not have to re-login every time they refresh the page
- From the **Store** Page Users can create their own products
- Only authenticated users currently logged in can post products
- From the **Product** Page a user can view all the details of a product
- From the **Product** Page a user can at that product to their wishlist
- A user can view all of their wished products from the **Wishlist** page
- A user can remove products from a wishlist
- Only the creator of a **Product** can delete it
- Only the creator of a **Product** can mark it **un-available**
- On the store page, only **available** products are returned by the server,
- A user Must have the ability to log in and out
- The Backend needs to be able to create and store the useres **Wishlist** 

### Bonus Ideas:
- A user can have multiple **wishlists**
- A user ratings(stars/points) can be added to products.
- A Wishlists can be private or shared
- A single product can have multiple "options" (think 1 shirt with many colors)
- A search function to find products faster
- Implement a Sale price, and a "on Sale" property for products
    - Sort Store Page to show on sale products first
- Products have category tags for easier searching by tags/category


<small>**AmaZen gift card is not guaranteed to hold any real world value and likely will not have any real world value outside of bragging rights over your fellow peers</small>
