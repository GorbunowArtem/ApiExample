'use client';

export default function Home() {

  async function getData() {
    const res = await fetch('http://localhost:5099/books')
    // The return value is *not* serialized
    // You can return Date, Map, Set, etc.
  }

  return (
      <main className="flex min-h-screen flex-col items-center justify-between p-24">
        <div className="mb-32 grid text-center lg:mb-0 lg:w-full lg:max-w-5xl lg:grid-cols-4 lg:text-left">
          <button
              onClick={getData}
              className="group rounded-lg border border-transparent px-5 py-4 transition-colors hover:border-gray-300 hover:bg-gray-100 hover:dark:border-neutral-700 hover:dark:bg-neutral-800/30"
          >
            <h2 className="mb-3 text-2xl font-semibold">
              Get products
              <span className="inline-block transition-transform group-hover:translate-x-1 motion-reduce:transform-none">
              -&gt;
            </span>
            </h2>
            <p className="m-0 max-w-[30ch] text-sm opacity-50">
              Get products
            </p>
          </button>

        </div>
      </main>
  );
}
