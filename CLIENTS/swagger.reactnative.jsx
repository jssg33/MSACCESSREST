import React, { useEffect, useState } from 'react';
import { SafeAreaView, ScrollView, StatusBar, StyleSheet, Text, useColorScheme, View } from 'react-native';

const App = () => {
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);

  useEffect(() => {
    fetch('http://localhost:8080/swagger/v1/swagger.json')
      .then((response) => response.json())
      .then((json) => setData(json))
      .catch((err) => setError(err));
  }, []);

  return (
    <SafeAreaView style={styles.container}>
      <StatusBar />
      <ScrollView contentInsetAdjustmentBehavior="automatic">
        <View style={styles.content}>
          {error ? (
            <Text style={styles.error}>Error: {error.message}</Text>
          ) : (
            <Text style={styles.data}>{JSON.stringify(data, null, 2)}</Text>
          )}
        </View>
      </ScrollView>
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
  },
  content: {
    padding: 20,
  },
  data: {
    fontSize: 14,
    color: '#333',
  },
  error: {
    fontSize: 14,
    color: 'red',
  },
});

export default App;