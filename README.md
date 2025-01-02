# KontentVR
![Unity](https://img.shields.io/badge/Unity-2023.3-black?logo=unity)
![Meta XR SDK](https://img.shields.io/badge/Meta%20XR%20SDK-60-blue?logo=meta)

## What is KontentVR
KontentVR is a Meta Quest media player straming appliation. It allows users to stream videos from a server and watch them in a virtual reality environment. Dedicated VR environments are available for each video (e.g. the Batcave for Batman films). The whole library is navigable in Netflix-esque fashion, with carousels of movies arranged by genre and saga, and a search feature has been implemented to find specific titles. The application loads its contents' data (Carousels, Film Title \ Description \ Poster) from a platform hosted by [Kineton](https://www.kineton.it/en/), communicating with it through HTTP.

## Why KontentVR exists
KontentVR has been developed for the [Enterprise Mobile Application Development](https://unisa.coursecatalogue.cineca.it/insegnamenti/2025/511231/2016/10004/500260?coorte=2024&schemaid=17338) course at the [University of Salerno](https://www.unisa.it/) by Antonio Cacciapuoti, Gabriele Moscato and Matteo Maiorano, in collaboration with [Kineton](https://www.kineton.it/en/). The project participated in the 10th edition of the [Unisa App Challenge](https://www.unisa.it/unisa-rescue-page/dettaglio/id/529/module/87/row/10307/app-challenge-sfida-all-ultima-app).

## How to use KontentVR
While the management platform is up and running, you can follow the steps below to use KontentVR:
1. Clone the repo
2. Open Unity Hub and add the project (Add -> Add Project From Disk -> Select the cloned repo)
3. Open the project
4. Open the `KontentAlphaAntonio` scene
5. Select the right platform (File -> Build Settings -> Android -> Switch Platform)
6. Connect your Meta Quest to your PC
7. Build the project and start it on device (File -> Build and Run).

