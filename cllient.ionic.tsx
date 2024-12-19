import React, { useEffect, useState } from 'react';
import { IonContent, IonHeader, IonPage, IonTitle, IonToolbar } from '@ionic/react';
import './App.css';

const App: React.FC = () => {
  const [data, setData] = useState<any>(null);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    fetch('http://localhost:8080/swagger/v1/swagger.json')
      .then((response) => response.json())
      .then((json) => setData(json))
      .catch((err) => setError(err.message));
  }, []);

  return (
    <IonPage>
      <IonHeader>
        <IonToolbar>
          <IonTitle>Student Data</IonTitle>
        </IonToolbar>
      </IonHeader>
      <IonContent className="ion-padding">
        {error ? (
          <pre style={{ color: 'red' }}>Error: {error}</pre>
        ) : (
          <pre>{JSON.stringify(data, null, 2)}</pre>
        )}
      </IonContent>
    </IonPage>
  );
};

export default App;