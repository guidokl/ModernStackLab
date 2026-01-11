import * as React from 'react'
import { useEffect, useState } from 'react'
//import reactLogo from './assets/react.svg'
//import viteLogo from '/vite.svg'
import './App.css'

// 1. THE INTERFACE (The Shape)
// This must match your C# Contact class exactly.
interface Contact {
    id: number;
    name: string;
    email: string;
    phone: string;
}

function App() {
    // 2. THE STATE (The Memory)
    // "contacts" holds the data. "setContacts" is the tool to update it.
    // We tell it: "This will hold an array of Contact objects (<Contact[]>), starting empty ([])."
    const [contacts, setContacts] = useState<Contact[]>([]);

    // 3. THE EFFECT (The Trigger)
    // useEffect runs code automatically when the component loads.
    useEffect(() => {
        fetch('http://localhost:5243/api/contacts')
            .then(response => response.json()) // Convert raw data to JSON
            .then(data => setContacts(data))   // Save the JSON into our State
            .catch(error => console.error('Error fetching data:', error)); // Log errors if any
    }, []); // The empty [] means "Run this only once when the page first loads".

    return (
        <div>
            <h1>Contactbase Frontend</h1>
            <p>React is running!</p>

            {/* 4. THE DISPLAY (The Render) */}
            {/* Loop through the contacts and show them as a list */}
            <ul>
                {contacts.map(contact => (
                    <li key={contact.id}>
                        <strong>{contact.name}</strong> - {contact.email} ({contact.phone})
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default App;
