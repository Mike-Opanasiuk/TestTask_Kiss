import { FC } from "react";
import { settings } from "../../settings";

export const HomePage: FC = () => {
   return (
      <div>
         {/* Hero Section */}
         <div className="min-h-[300px] bg-gradient-to-r from-blue-500 to-purple-500 rounded-2xl flex items-center justify-center p-8 text-white">
            <div className="">
               <h1 className="text-6xl font-extrabold mb-4">
                  Find <br />
                  <span className="text-pink-300">your</span> <br />
                  best <br />
                  match
               </h1>
               <a href={settings.authUrl} className="w-60 h-16 leading-[64px] block text-center rounded-full bg-white text-xl hover:bg-pink-50 text-pink-500 transition">
                  Get Started
               </a>
            </div>
            <img src="/background.png" alt="Background" className="w-32 md:w-1/2 lg:w-2/3 ml-8 scale-150 md:scale-100" />
         </div>

         {/* Explore Section */}
         <div className="bg-pink-200 p-8 mt-24 rounded-t-2xl">
            <div className="max-w-4xl mx-auto flex items-center">
               <div className="w-1/2">
                  <img src="https://images.unsplash.com/photo-1513118172236-00b7cc57e1fa?q=80&w=2380&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="About Us" className="w-full rounded-lg shadow-lg" />
               </div>
               <div className="w-1/2 pl-8">
                  <h2 className="text-4xl font-bold mb-6 text-white">Explore</h2>
                  <p className="text-gray-800">
                     Discover interesting people near you and explore their profiles.
                  </p>
               </div>
            </div>
         </div>

         {/* Connect Section */}
         <div className="bg-purple-100 p-8">
            <div className="max-w-4xl mx-auto">
               <h2 className="text-4xl font-bold mb-6 text-black">Connect</h2>
               <ul className="text-gray-700 space-y-2">
                  <li>Connect with like-minded individuals</li>
                  <li>and</li>
                  <li>start meaningful conversations.</li>
                  {/* Add more features as needed */}
               </ul>
            </div>
         </div>

         {/* Match Section */}
         <div className="bg-yellow-200 p-8 rounded-b-2xl">
            <div className="max-w-4xl mx-auto flex items-center">
               <div className="w-1/2 pr-8">
                  <h2 className="text-4xl font-bold mb-6 text-black">Match</h2>
                  <ul className="text-gray-700 space-y-2">
                     <li>Find your perfect match</li>
                     <li>and</li>
                     <li>build a connection that lasts.</li>
                     {/* Add more features as needed */}
                  </ul>
                  {/* Add step-by-step explanation of the process */}
               </div>
               <div className="w-1/2">
                  <img src="https://images.unsplash.com/photo-1586942729823-a31b812f9b98?q=80&w=3870&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" alt="How It Works" className="w-full rounded-lg shadow-lg" />
               </div>
            </div>
         </div>

         {/* Call to Action Section */}
         <div className="mt-24 min-h-[300px] bg-gradient-to-r from-blue-500 to-purple-500 rounded-t-2xl flex items-center justify-center p-8 text-white">
            <div className="text-center">
               <h2 className="text-4xl font-bold mb-4">
                  Ready to find your best match?
               </h2>
               <a href={settings.authUrl} className="mx-auto block w-40 h-16 leading-[64px] rounded-full bg-white text-xl hover:bg-pink-50 text-pink-500 transition">
                  Get Started
               </a>
            </div>
         </div>
      </div>

   )
}
