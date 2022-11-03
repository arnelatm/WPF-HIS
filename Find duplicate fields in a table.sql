SELECT a.*
FROM users a
JOIN (SELECT username, email, COUNT(*)
FROM users 
GROUP BY username, email
HAVING count(*) > 1 ) b
ON a.username = b.username
AND a.email = b.email
ORDER BY a.email