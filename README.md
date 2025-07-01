
# 🛡️ TFM - Simulación de Campaña de Ataque en Entorno Corporativo

Este Trabajo Fin de Máster (TFM) tiene como objetivo simular una campaña de ataque dirigida contra una organización ficticia con una arquitectura de red vulnerable, con el propósito de analizar sus deficiencias de seguridad y proponer contramedidas.

## 📚 Descripción del proyecto

Se ha diseñado un entorno controlado que emula una organización llamada `E-Corp.local`, compuesta por:

- Controlador de dominio con Windows Server 2012 R2
- Equipos cliente con Windows 7 Enterprise SP1
- Segmentación de red básica
- Servicios vulnerables expuestos

Se ha desarrollado y utilizado un malware tipo **dropper** escrito en C# (.NET), camuflado como instalador de KeePass, que simula un primer vector de entrada en la organización. El dropper establece conexión con el **C2 Havoc** y permite ejecutar tareas de post-explotación, movimiento lateral y persistencia.

## ⚙️ Arquitectura de Red

```
Atacante (Kali) → Máquina puente (pivot) → Red interna
                                        └→ Controlador de Dominio WS2012 (192.168.150.2)
                                        └→ Equipos Windows 7 (192.168.150.4 / .5)
```

### Herramientas y tecnologías

- 🐧 Kali Linux
- 🪟 Windows Server 2012 R2 / Windows 7 SP1
- 🧠 Ligolo-ng (túnel pivoting)
- 🧬 Havoc Framework (C2)
- 💣 C# (.NET) Dropper
- 📡 EternalBlue (MS17-010) Exploit
- 🐚 Powershell, WMI, Regedit, y técnicas de persistencia

## 📈 Resultados

Se ha demostrado cómo, con recursos limitados y vulnerabilidades comunes, un atacante puede:

- Obtener acceso inicial a través de ingeniería social.
- Establecer persistencia sin ser detectado.
- Pivotar y moverse lateralmente a la red interna.
- Exfiltrar credenciales (SAM/NTDS.dit).
- Comprometer el controlador de dominio.

## 🔒 Principales vulnerabilidades identificadas

- Uso de sistemas operativos obsoletos sin parches.
- Segmentación de red ineficaz.
- Falta de EDR/AV y mecanismos de monitorización.
- Permisos mal gestionados y comparticiones inseguras.
- Falta de formación frente a phishing.

## 🧯 Recomendaciones de mejora

- Actualización y parcheo de sistemas.
- Segmentación de red con VLANs y firewalls internos.
- Implementación de soluciones EDR/AV.
- Gestión adecuada de privilegios mínimos.
- Monitorización continua y análisis de logs.
- Concienciación y formación de empleados.

## 📁 Estructura del repositorio

```
/src                → Código fuente del dropper en C#
/informes           → Documentación del TFM (PDF, presentaciones)
/infraestructura    → Diagramas de red, configuración del entorno
/exploits           → Scripts y exploits usados (uso académico)
/screenshots        → Capturas relevantes del entorno
```

## 🧠 Autor

**Nombre:** KaoXx (Jesús Andrés Altozano)
**Máster:** Ciberseguridad (UNIR)  
**Empresa:** ISDEFE

---

## ⚠️ Aviso Legal

> Este proyecto tiene fines estrictamente académicos. No se promueve el uso malicioso de ninguna herramienta, código o técnica aquí descrita. Todo el experimento se ha realizado en un entorno controlado y cerrado, sin afectar a terceros.

---

## 📎 Licencia

MIT License
